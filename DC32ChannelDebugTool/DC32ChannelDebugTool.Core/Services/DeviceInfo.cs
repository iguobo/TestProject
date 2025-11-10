using System;

namespace DC32ChannelDebugTool.Core.Models
{
    /// <summary>
    /// 设备信息模型
    /// 包含设备的所有配置和状态信息
    /// </summary>
    public class DeviceInfo
    {
        #region 基本信息

        /// <summary>
        /// 设备地址 (1-128)
        /// </summary>
        public byte Address { get; set; }

        /// <summary>
        /// 版本号 (如: "1.0")
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// 板名称
        /// </summary>
        public string BoardName { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNumber { get; set; }

        #endregion

        #region IO配置

        /// <summary>
        /// IO方向配置
        /// bit=1表示输出，bit=0表示输入
        /// </summary>
        public ushort IoDirection { get; set; }

        /// <summary>
        /// IO值
        /// </summary>
        public ushort IoValue { get; set; }

        #endregion

        #region 温度和风扇

        /// <summary>
        /// 设定温度 (℃)
        /// </summary>
        public byte SetTemperature { get; set; }

        /// <summary>
        /// 当前温度 (℃)
        /// </summary>
        public byte CurrentTemperature { get; set; }

        /// <summary>
        /// 风扇电流 (单位: mA)
        /// </summary>
        public ushort FanCurrent { get; set; }

        /// <summary>
        /// 风扇电流 (单位: A) - 只读属性
        /// </summary>
        public double FanCurrentInAmps => FanCurrent / 1000.0;

        #endregion

        #region 状态信息

        /// <summary>
        /// AC on 信号是否到位
        /// </summary>
        public bool AcOnSignal { get; set; }

        /// <summary>
        /// 跳落状态 (32位，每位对应一个通道)
        /// </summary>
        public uint DropStatus { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime LastUpdateTime { get; set; }

        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsOnline { get; set; }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 检查指定通道是否跳落
        /// </summary>
        /// <param name="channelNumber">通道号 (1-32)</param>
        /// <returns>是否跳落</returns>
        public bool IsChannelDropped(int channelNumber)
        {
            if (channelNumber < 1 || channelNumber > 32)
                throw new ArgumentOutOfRangeException(nameof(channelNumber), "通道号必须在1-32之间");

            int bitPosition = channelNumber - 1;
            return (DropStatus & (1u << bitPosition)) != 0;
        }

        /// <summary>
        /// 获取所有跳落的通道号
        /// </summary>
        /// <returns>跳落的通道号数组</returns>
        public int[] GetDroppedChannels()
        {
            var droppedChannels = new System.Collections.Generic.List<int>();
            for (int i = 1; i <= 32; i++)
            {
                if (IsChannelDropped(i))
                {
                    droppedChannels.Add(i);
                }
            }
            return droppedChannels.ToArray();
        }

        /// <summary>
        /// 获取跳落通道数量
        /// </summary>
        public int DroppedChannelCount
        {
            get
            {
                int count = 0;
                uint status = DropStatus;
                while (status != 0)
                {
                    count += (int)(status & 1);
                    status >>= 1;
                }
                return count;
            }
        }

        #endregion

        /// <summary>
        /// 转换为可读的字符串
        /// </summary>
        public override string ToString()
        {
            return $"设备[地址:{Address}, 名称:{BoardName}, SN:{SerialNumber}, 版本:{Version}]";
        }
    }
}