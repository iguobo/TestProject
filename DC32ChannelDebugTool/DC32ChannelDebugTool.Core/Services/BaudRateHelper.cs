using System;

namespace DC32ChannelDebugTool.Core.Models
{
    /// <summary>
    /// 波特率转换帮助类
    /// 用于在波特率代码和实际波特率值之间转换
    /// </summary>
    public static class BaudRateHelper
    {
        /// <summary>
        /// 支持的波特率列表
        /// </summary>
        public static readonly int[] SupportedBaudRates = { 9600, 19200, 38400, 57600 };

        /// <summary>
        /// 将波特率代码转换为实际波特率
        /// </summary>
        /// <param name="code">波特率代码 (0-3)</param>
        /// <returns>实际波特率</returns>
        public static int ConvertCodeToBaudRate(ushort code)
        {
            switch (code)
            {
                case 0: return 9600;
                case 1: return 19200;
                case 2: return 38400;
                case 3: return 57600;
                default: return 57600; // 默认返回最高波特率
            }
        }

        /// <summary>
        /// 将实际波特率转换为波特率代码
        /// </summary>
        /// <param name="baudRate">实际波特率</param>
        /// <returns>波特率代码 (0-3)</returns>
        public static ushort ConvertBaudRateToCode(int baudRate)
        {
            switch (baudRate)
            {
                case 9600: return 0;
                case 19200: return 1;
                case 38400: return 2;
                case 57600: return 3;
                default:
                    throw new ArgumentException($"不支持的波特率: {baudRate}，支持的波特率为: 9600, 19200, 38400, 57600");
            }
        }

        /// <summary>
        /// 检查波特率是否受支持
        /// </summary>
        public static bool IsSupported(int baudRate)
        {
            return Array.IndexOf(SupportedBaudRates, baudRate) >= 0;
        }
    }
}