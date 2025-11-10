using System;

namespace DC32ChannelDebugTool.Core.Models
{
    /// <summary>
    /// 电压数据模型
    /// 表示单个通道的电压测量数据
    /// </summary>
    public class VoltageData
    {
        /// <summary>
        /// 通道编号 (1-32)
        /// </summary>
        public int ChannelNumber { get; set; }

        /// <summary>
        /// 原始数据值 (从寄存器读取的原始16位值)
        /// </summary>
        public ushort RawValue { get; set; }

        /// <summary>
        /// 电压值 (单位: V)
        /// </summary>
        public double Voltage { get; set; }

        /// <summary>
        /// 是否跳落
        /// </summary>
        public bool IsDropped { get; set; }

        /// <summary>
        /// 跳落持续时间 (单位: 秒)
        /// </summary>
        public ushort DropDuration { get; set; }

        /// <summary>
        /// 跳落阈值 (单位: V)
        /// </summary>
        public double DropThreshold { get; set; }

        /// <summary>
        /// 采集时间
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// 设备地址
        /// </summary>
        public byte DeviceAddress { get; set; }

        /// <summary>
        /// 将原始数据转换为电压值
        /// 根据协议: 
        /// - 当数据 > 0x8000 时，电压值 = (数据 - 0x8000) / 100V
        /// - 否则，电压值 = 数据 / 1000V
        /// </summary>
        /// <param name="rawValue">原始16位数据</param>
        /// <returns>电压值(V)</returns>
        public static double ConvertRawToVoltage(ushort rawValue)
        {
            if (rawValue > 0x8000)
            {
                return (rawValue - 0x8000) / 100.0;
            }
            else
            {
                return rawValue / 1000.0;
            }
        }

        /// <summary>
        /// 将电压值转换为原始数据
        /// </summary>
        /// <param name="voltage">电压值(V)</param>
        /// <returns>原始16位数据</returns>
        public static ushort ConvertVoltageToRaw(double voltage)
        {
            if (voltage > 32.768)
            {
                return (ushort)(voltage * 100 + 0x8000);
            }
            else
            {
                return (ushort)(voltage * 1000);
            }
        }

        /// <summary>
        /// 将跳落阈值电压转换为原始数据
        /// 根据协议: 数值1000对应10V
        /// </summary>
        public static ushort ConvertThresholdToRaw(double voltage)
        {
            return (ushort)(voltage * 100);
        }

        /// <summary>
        /// 将原始阈值数据转换为电压
        /// </summary>
        public static double ConvertRawToThreshold(ushort rawValue)
        {
            return rawValue / 100.0;
        }
    }
}