using System;
using System.IO.Ports;
using System.Threading;

namespace DC32ChannelDebugTool.Communication
{
    /// <summary>
    /// Modbus RTU 主站实现
    /// 支持功能码 0x03(读保持寄存器) 和 0x10(写多个寄存器)
    /// </summary>
    public class ModbusRtuMaster : IDisposable
    {
        private SerialPort _serialPort;
        private readonly object _syncLock = new object();

        /// <summary>
        /// 默认超时时间(毫秒)
        /// </summary>
        public int Timeout { get; set; } = 1000;

        /// <summary>
        /// 帧间延时(毫秒) - Modbus RTU要求的最小间隔
        /// </summary>
        public int FrameDelay { get; set; } = 50;

        /// <summary>
        /// 是否已连接
        /// </summary>
        public bool IsConnected => _serialPort?.IsOpen ?? false;

        /// <summary>
        /// 当前串口名称
        /// </summary>
        public string PortName => _serialPort?.PortName;

        /// <summary>
        /// 当前波特率
        /// </summary>
        public int BaudRate => _serialPort?.BaudRate ?? 0;

        /// <summary>
        /// 打开串口连接
        /// </summary>
        /// <param name="portName">串口名称 (如 "COM1")</param>
        /// <param name="baudRate">波特率 (9600/19200/38400/57600)</param>
        /// <param name="parity">校验位</param>
        /// <param name="dataBits">数据位</param>
        /// <param name="stopBits">停止位</param>
        /// <returns>是否连接成功</returns>
        public bool Connect(string portName, int baudRate,
            Parity parity = Parity.None,
            int dataBits = 8,
            StopBits stopBits = StopBits.One)
        {
            try
            {
                // 如果已经打开，先关闭
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                    _serialPort.Dispose();
                }

                _serialPort = new SerialPort
                {
                    PortName = portName,
                    BaudRate = baudRate,
                    Parity = parity,
                    DataBits = dataBits,
                    StopBits = stopBits,
                    ReadTimeout = Timeout,
                    WriteTimeout = Timeout
                };

                _serialPort.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"打开串口失败: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// 关闭串口连接
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
            }
            catch
            {
                // 忽略关闭时的异常
            }
        }

        /// <summary>
        /// 读取保持寄存器 (功能码 0x03)
        /// </summary>
        /// <param name="slaveAddress">从站地址 (1-128)</param>
        /// <param name="startAddress">起始寄存器地址</param>
        /// <param name="numberOfPoints">寄存器数量</param>
        /// <returns>寄存器值数组</returns>
        public ushort[] ReadHoldingRegisters(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            lock (_syncLock)
            {
                if (!IsConnected)
                    throw new InvalidOperationException("串口未连接");

                // 构建请求帧: 地址 + 功能码 + 起始地址 + 数量 + CRC
                byte[] request = new byte[6];
                request[0] = slaveAddress;
                request[1] = 0x03;  // 功能码
                request[2] = (byte)(startAddress >> 8);   // 起始地址高字节
                request[3] = (byte)(startAddress & 0xFF); // 起始地址低字节
                request[4] = (byte)(numberOfPoints >> 8);   // 数量高字节
                request[5] = (byte)(numberOfPoints & 0xFF); // 数量低字节

                // 添加CRC校验
                byte[] frameWithCrc = ModbusCrc.AppendCrc(request, 6);

                // 清空缓冲区
                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();

                // 发送请求
                _serialPort.Write(frameWithCrc, 0, frameWithCrc.Length);

                // 等待响应
                Thread.Sleep(FrameDelay);

                // 计算期望的响应长度: 地址(1) + 功能码(1) + 字节数(1) + 数据(N*2) + CRC(2)
                int expectedLength = 5 + (numberOfPoints * 2);
                byte[] response = new byte[expectedLength];

                int bytesRead = 0;
                int retries = 10;
                while (bytesRead < expectedLength && retries > 0)
                {
                    if (_serialPort.BytesToRead > 0)
                    {
                        bytesRead += _serialPort.Read(response, bytesRead, expectedLength - bytesRead);
                    }
                    else
                    {
                        Thread.Sleep(10);
                        retries--;
                    }
                }

                if (bytesRead != expectedLength)
                    throw new TimeoutException($"读取超时，期望{expectedLength}字节，实际读取{bytesRead}字节");

                // 验证CRC
                if (!ModbusCrc.Verify(response, expectedLength))
                    throw new Exception("CRC校验失败");

                // 验证从站地址和功能码
                if (response[0] != slaveAddress)
                    throw new Exception($"从站地址不匹配，期望{slaveAddress}，实际{response[0]}");

                if (response[1] == (0x80 | 0x03)) // 错误响应
                    throw new Exception($"Modbus错误响应，异常码: {response[2]}");

                if (response[1] != 0x03)
                    throw new Exception($"功能码不匹配，期望0x03，实际0x{response[1]:X2}");

                // 解析数据 (高字节在前)
                int byteCount = response[2];
                if (byteCount != numberOfPoints * 2)
                    throw new Exception("数据长度不匹配");

                ushort[] registers = new ushort[numberOfPoints];
                for (int i = 0; i < numberOfPoints; i++)
                {
                    int offset = 3 + (i * 2);
                    registers[i] = (ushort)((response[offset] << 8) | response[offset + 1]);
                }

                return registers;
            }
        }

        /// <summary>
        /// 写多个寄存器 (功能码 0x10)
        /// </summary>
        /// <param name="slaveAddress">从站地址 (1-128)</param>
        /// <param name="startAddress">起始寄存器地址</param>
        /// <param name="data">要写入的数据</param>
        /// <returns>是否写入成功</returns>
        public bool WriteMultipleRegisters(byte slaveAddress, ushort startAddress, ushort[] data)
        {
            lock (_syncLock)
            {
                if (!IsConnected)
                    throw new InvalidOperationException("串口未连接");

                ushort numberOfPoints = (ushort)data.Length;
                byte byteCount = (byte)(numberOfPoints * 2);

                // 构建请求帧
                byte[] request = new byte[7 + byteCount];
                request[0] = slaveAddress;
                request[1] = 0x10;  // 功能码
                request[2] = (byte)(startAddress >> 8);
                request[3] = (byte)(startAddress & 0xFF);
                request[4] = (byte)(numberOfPoints >> 8);
                request[5] = (byte)(numberOfPoints & 0xFF);
                request[6] = byteCount;

                // 填充数据 (高字节在前)
                for (int i = 0; i < numberOfPoints; i++)
                {
                    request[7 + (i * 2)] = (byte)(data[i] >> 8);
                    request[7 + (i * 2) + 1] = (byte)(data[i] & 0xFF);
                }

                // 添加CRC
                byte[] frameWithCrc = ModbusCrc.AppendCrc(request, request.Length);

                // 清空缓冲区
                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();

                // 发送请求
                _serialPort.Write(frameWithCrc, 0, frameWithCrc.Length);

                // 等待响应
                Thread.Sleep(FrameDelay);

                // 读取响应 (功能码0x10的响应固定8字节)
                byte[] response = new byte[8];
                int bytesRead = 0;
                int retries = 10;

                while (bytesRead < 8 && retries > 0)
                {
                    if (_serialPort.BytesToRead > 0)
                    {
                        bytesRead += _serialPort.Read(response, bytesRead, 8 - bytesRead);
                    }
                    else
                    {
                        Thread.Sleep(10);
                        retries--;
                    }
                }

                if (bytesRead != 8)
                    throw new TimeoutException($"写入超时，期望8字节响应，实际读取{bytesRead}字节");

                // 验证CRC
                if (!ModbusCrc.Verify(response, 8))
                    throw new Exception("CRC校验失败");

                // 验证从站地址和功能码
                if (response[0] != slaveAddress)
                    throw new Exception("从站地址不匹配");

                if (response[1] == (0x80 | 0x10)) // 错误响应
                    throw new Exception($"Modbus错误响应，异常码: {response[2]}");

                if (response[1] != 0x10)
                    throw new Exception("功能码不匹配");

                return true;
            }
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Disconnect();
            _serialPort?.Dispose();
        }
    }
}