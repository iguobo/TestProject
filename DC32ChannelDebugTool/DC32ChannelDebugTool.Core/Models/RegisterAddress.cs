namespace DC32ChannelDebugTool.Core.Models
{
    /// <summary>
    /// 寄存器地址定义
    /// 根据《32通道直流电压检测板通信协议》定义
    /// </summary>
    public static class RegisterAddress
    {
        #region 基本配置寄存器 (16位格式)

        /// <summary>
        /// 设备地址 (0x8000) - 取值范围: 1-128
        /// </summary>
        public const ushort DEVICE_ADDRESS = 0x8000;

        /// <summary>
        /// 版本号 (0x8001) - 如: 10 表示 1.0
        /// </summary>
        public const ushort VERSION = 0x8001;

        /// <summary>
        /// 波特率 (0x8002)
        /// 0=9600, 1=19200, 2=38400, 3=57600
        /// </summary>
        public const ushort BAUD_RATE = 0x8002;

        /// <summary>
        /// IO方向 (0x8003)
        /// bit值为1表示输出，为0表示输入
        /// </summary>
        public const ushort IO_DIRECTION = 0x8003;

        /// <summary>
        /// IO值 (0x8004)
        /// </summary>
        public const ushort IO_VALUE = 0x8004;

        /// <summary>
        /// 跳落状态 (0x8005) - 占用2个寄存器
        /// 每个bit对应一个通道，1表示跳落
        /// </summary>
        public const ushort DROP_STATUS = 0x8005;

        /// <summary>
        /// 设定温度 (0x8007)
        /// </summary>
        public const ushort SET_TEMPERATURE = 0x8007;

        /// <summary>
        /// 当前温度值 (0x8008)
        /// </summary>
        public const ushort CURRENT_TEMPERATURE = 0x8008;

        /// <summary>
        /// 风扇电流 (0x8009) - 单位: mA, 如: 1000 表示 1A
        /// </summary>
        public const ushort FAN_CURRENT = 0x8009;

        /// <summary>
        /// AC on 信号是否到位 (0x800A)
        /// 1=到位, 0=未到位
        /// </summary>
        public const ushort AC_ON_SIGNAL = 0x800A;

        #endregion

        #region 电压相关寄存器 (32路)

        /// <summary>
        /// 32通道电压起始地址 (0x8010) - 占用32个寄存器
        /// 0x8010-0x802F 对应通道1-32
        /// </summary>
        public const ushort VOLTAGE_START = 0x8010;

        /// <summary>
        /// 32通道跳落持续时间 (0x8030) - 占用32个寄存器
        /// 单位: 秒, 最大65535秒
        /// </summary>
        public const ushort DROP_TIME = 0x8030;

        /// <summary>
        /// 32通道跳落电压阈值 (0x8050) - 占用32个寄存器
        /// 数值1000对应10V，当输入电压低于这个值时，产生跳落标志
        /// </summary>
        public const ushort DROP_THRESHOLD = 0x8050;

        #endregion

        #region 校正数据

        /// <summary>
        /// 用于校正的原始数据1 (0x80C0) - 占用32个寄存器
        /// </summary>
        public const ushort CALIBRATION_DATA1 = 0x80C0;

        /// <summary>
        /// 用于校正的原始数据2 (0x80E0) - 占用32个寄存器
        /// </summary>
        public const ushort CALIBRATION_DATA2 = 0x80E0;

        #endregion

        #region 设备标识

        /// <summary>
        /// 板名称 (0x8800) - 占用32个寄存器 (64字节)
        /// UNICODE文字，如: 冠佳32通道直流电压检测板GJ_Vdc32_V1.0
        /// </summary>
        public const ushort BOARD_NAME = 0x8800;

        /// <summary>
        /// 序列号SN (0x8820) - 占用31个寄存器 (62字节)
        /// 出厂时写入，默认全为0xFFFF
        /// </summary>
        public const ushort SERIAL_NUMBER = 0x8820;

        #endregion

        #region Bootloader

        /// <summary>
        /// Bootloader 进入指令 (0xbbbb)
        /// </summary>
        public const ushort BOOTLOADER_ENTER = 0xbbbb;

        /// <summary>
        /// Bootloader 数据指令 (0xbbbc)
        /// </summary>
        public const ushort BOOTLOADER_DATA = 0xbbbc;

        #endregion

        #region 常量定义

        /// <summary>
        /// 电压通道数量
        /// </summary>
        public const int VOLTAGE_CHANNEL_COUNT = 32;

        /// <summary>
        /// 最小设备地址
        /// </summary>
        public const byte MIN_DEVICE_ADDRESS = 1;

        /// <summary>
        /// 最大设备地址
        /// </summary>
        public const byte MAX_DEVICE_ADDRESS = 128;

        #endregion
    }
}