using System;
using System.Text;
using DC32ChannelDebugTool.Communication;
using DC32ChannelDebugTool.Core.Models;

namespace DC32ChannelDebugTool.Core.Services
{
    /// <summary>
    /// 设备服务 - 封装所有设备通信和数据处理逻辑
    /// </summary>
    public class DeviceService : IDisposable
    {
        private readonly ModbusRtuMaster _modbus;
        private byte _currentDeviceAddress = 1;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DeviceService()
        {
            _modbus = new ModbusRtuMaster();
        }

        #region 连接管理

        /// <summary>
        /// 是否已连接
        /// </summary>
        public bool IsConnected => _modbus.IsConnected;

        /// <summary>
        /// 当前串口名称
        /// </summary>
        public string PortName => _modbus.PortName;

        /// <summary>
        /// 当前波特率
        /// </summary>
        public int BaudRate => _modbus.BaudRate;

        /// <summary>
        /// 当前设备地址
        /// </summary>
        public byte CurrentDeviceAddress => _currentDeviceAddress;

        /// <summary>
        /// 连接设备
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率</param>
        /// <returns>是否连接成功</returns>
        public bool Connect(string portName, int baudRate)
        {
            try
            {
                return _modbus.Connect(portName, baudRate);
            }
            catch (Exception ex)
            {
                throw new Exception($"连接设备失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        public void Disconnect()
        {
            _modbus.Disconnect();
        }

        /// <summary>
        /// 设置当前设备地址
        /// </summary>
        public void SetDeviceAddress(byte address)
        {
            if (address < RegisterAddress.MIN_DEVICE_ADDRESS || address > RegisterAddress.MAX_DEVICE_ADDRESS)
                throw new ArgumentOutOfRangeException(nameof(address),
                    $"设备地址必须在{RegisterAddress.MIN_DEVICE_ADDRESS}-{RegisterAddress.MAX_DEVICE_ADDRESS}之间");

            _currentDeviceAddress = address;
        }

        #endregion

        #region 读取电压数据

        /// <summary>
        /// 读取所有32路电压值
        /// </summary>
        /// <returns>电压数据数组</returns>
        public VoltageData[] ReadAllVoltages()
        {
            // 读取32个电压寄存器
            ushort[] voltageRaw = _modbus.ReadHoldingRegisters(
                _currentDeviceAddress,
                RegisterAddress.VOLTAGE_START,
                RegisterAddress.VOLTAGE_CHANNEL_COUNT);

            VoltageData[] voltages = new VoltageData[RegisterAddress.VOLTAGE_CHANNEL_COUNT];

            for (int i = 0; i < RegisterAddress.VOLTAGE_CHANNEL_COUNT; i++)
            {
                voltages[i] = new VoltageData
                {
                    ChannelNumber = i + 1,
                    RawValue = voltageRaw[i],
                    Voltage = VoltageData.ConvertRawToVoltage(voltageRaw[i]),
                    Timestamp = DateTime.Now,
                    DeviceAddress = _currentDeviceAddress
                };
            }

            return voltages;
        }

        /// <summary>
        /// 读取单个通道的电压
        /// </summary>
        /// <param name="channelNumber">通道号 (1-32)</param>
        public VoltageData ReadSingleVoltage(int channelNumber)
        {
            if (channelNumber < 1 || channelNumber > 32)
                throw new ArgumentOutOfRangeException(nameof(channelNumber), "通道号必须在1-32之间");

            ushort address = (ushort)(RegisterAddress.VOLTAGE_START + channelNumber - 1);
            ushort[] data = _modbus.ReadHoldingRegisters(_currentDeviceAddress, address, 1);

            return new VoltageData
            {
                ChannelNumber = channelNumber,
                RawValue = data[0],
                Voltage = VoltageData.ConvertRawToVoltage(data[0]),
                Timestamp = DateTime.Now,
                DeviceAddress = _currentDeviceAddress
            };
        }

        #endregion

        #region 读取设备信息

        /// <summary>
        /// 读取完整的设备信息
        /// </summary>
        public DeviceInfo ReadDeviceInfo()
        {
            var info = new DeviceInfo
            {
                LastUpdateTime = DateTime.Now,
                IsOnline = true
            };

            try
            {
                // 读取基本信息
                info.Address = (byte)_modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.DEVICE_ADDRESS, 1)[0];

                ushort versionRaw = _modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.VERSION, 1)[0];
                info.Version = $"{versionRaw / 10.0:F1}";

                ushort baudRateCode = _modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.BAUD_RATE, 1)[0];
                info.BaudRate = BaudRateHelper.ConvertCodeToBaudRate(baudRateCode);

                // 读取IO配置
                info.IoDirection = _modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.IO_DIRECTION, 1)[0];
                info.IoValue = _modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.IO_VALUE, 1)[0];

                // 读取跳落状态 (2个寄存器组成32位)
                ushort[] dropStatus = _modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.DROP_STATUS, 2);
                info.DropStatus = (uint)((dropStatus[0] << 16) | dropStatus[1]);

                // 读取温度信息
                info.SetTemperature = (byte)_modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.SET_TEMPERATURE, 1)[0];
                info.CurrentTemperature = (byte)_modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.CURRENT_TEMPERATURE, 1)[0];

                // 读取风扇电流
                info.FanCurrent = _modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.FAN_CURRENT, 1)[0];

                // 读取AC信号状态
                info.AcOnSignal = _modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.AC_ON_SIGNAL, 1)[0] == 1;

                // 读取板名称 (32个寄存器，64字节)
                ushort[] boardNameData = _modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.BOARD_NAME, 32);
                info.BoardName = ConvertRegistersToString(boardNameData);

                // 读取序列号 (31个寄存器，62字节)
                ushort[] snData = _modbus.ReadHoldingRegisters(_currentDeviceAddress, RegisterAddress.SERIAL_NUMBER, 31);
                info.SerialNumber = ConvertRegistersToString(snData);

                return info;
            }
            catch (Exception ex)
            {
                info.IsOnline = false;
                throw new Exception($"读取设备信息失败: {ex.Message}", ex);
            }
        }

        #endregion

        #region 写入配置

        /// <summary>
        /// 写入设备地址
        /// </summary>
        public bool WriteDeviceAddress(byte newAddress)
        {
            if (newAddress < RegisterAddress.MIN_DEVICE_ADDRESS || newAddress > RegisterAddress.MAX_DEVICE_ADDRESS)
                throw new ArgumentOutOfRangeException(nameof(newAddress));

            return _modbus.WriteMultipleRegisters(_currentDeviceAddress, RegisterAddress.DEVICE_ADDRESS, new ushort[] { newAddress });
        }

        /// <summary>
        /// 写入波特率
        /// </summary>
        public bool WriteBaudRate(int baudRate)
        {
            ushort code = BaudRateHelper.ConvertBaudRateToCode(baudRate);
            return _modbus.WriteMultipleRegisters(_currentDeviceAddress, RegisterAddress.BAUD_RATE, new ushort[] { code });
        }

        /// <summary>
        /// 写入IO方向
        /// </summary>
        public bool WriteIoDirection(ushort ioDirection)
        {
            return _modbus.WriteMultipleRegisters(_currentDeviceAddress, RegisterAddress.IO_DIRECTION, new ushort[] { ioDirection });
        }

        /// <summary>
        /// 写入IO值
        /// </summary>
        public bool WriteIoValue(ushort ioValue)
        {
            return _modbus.WriteMultipleRegisters(_currentDeviceAddress, RegisterAddress.IO_VALUE, new ushort[] { ioValue });
        }

        /// <summary>
        /// 写入设定温度
        /// </summary>
        public bool WriteSetTemperature(byte temperature)
        {
            return _modbus.WriteMultipleRegisters(_currentDeviceAddress, RegisterAddress.SET_TEMPERATURE, new ushort[] { temperature });
        }

        /// <summary>
        /// 写入单个通道的跳落阈值
        /// </summary>
        public bool WriteDropThreshold(int channelNumber, double thresholdVoltage)
        {
            if (channelNumber < 1 || channelNumber > 32)
                throw new ArgumentOutOfRangeException(nameof(channelNumber));

            ushort address = (ushort)(RegisterAddress.DROP_THRESHOLD + channelNumber - 1);
            ushort rawValue = VoltageData.ConvertThresholdToRaw(thresholdVoltage);

            return _modbus.WriteMultipleRegisters(_currentDeviceAddress, address, new ushort[] { rawValue });
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 将寄存器数据转换为字符串 (支持UNICODE)
        /// </summary>
        private string ConvertRegistersToString(ushort[] registers)
        {
            byte[] bytes = new byte[registers.Length * 2];
            for (int i = 0; i < registers.Length; i++)
            {
                bytes[i * 2] = (byte)(registers[i] >> 8);      // 高字节
                bytes[i * 2 + 1] = (byte)(registers[i] & 0xFF); // 低字节
            }

            // 查找字符串结束位置 (0x00)
            int length = Array.FindIndex(bytes, b => b == 0);
            if (length == -1) length = bytes.Length;

            // 尝试UTF-16解码（UNICODE）
            try
            {
                return Encoding.Unicode.GetString(bytes, 0, length).TrimEnd('\0');
            }
            catch
            {
                // 如果失败，尝试UTF-8
                return Encoding.UTF8.GetString(bytes, 0, length).TrimEnd('\0');
            }
        }

        #endregion

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            _modbus?.Dispose();
        }
    }
}