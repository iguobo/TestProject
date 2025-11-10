using System;

namespace DC32ChannelDebugTool.Communication
{
    /// <summary>
    /// Modbus CRC16 校验工具类
    /// 用于计算和验证Modbus RTU通信的CRC校验码
    /// </summary>
    public static class ModbusCrc
    {
        /// <summary>
        /// 计算Modbus CRC16校验码
        /// </summary>
        /// <param name="data">待校验的数据</param>
        /// <param name="length">数据长度</param>
        /// <returns>16位CRC校验码</returns>
        public static ushort Calculate(byte[] data, int length)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            if (length > data.Length)
                throw new ArgumentException("长度超出数据范围", nameof(length));

            ushort crc = 0xFFFF;

            for (int i = 0; i < length; i++)
            {
                crc ^= data[i];

                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x0001) != 0)
                    {
                        crc >>= 1;
                        crc ^= 0xA001;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }

            return crc;
        }

        /// <summary>
        /// 验证CRC校验码是否正确
        /// </summary>
        /// <param name="data">包含CRC的完整数据（CRC在最后两个字节）</param>
        /// <param name="length">数据总长度（包含CRC）</param>
        /// <returns>校验是否通过</returns>
        public static bool Verify(byte[] data, int length)
        {
            if (length < 3)
                return false;

            // 提取接收到的CRC（低字节在前，高字节在后）
            ushort receivedCrc = (ushort)(data[length - 2] | (data[length - 1] << 8));

            // 计算数据部分的CRC
            ushort calculatedCrc = Calculate(data, length - 2);

            return receivedCrc == calculatedCrc;
        }

        /// <summary>
        /// 为数据添加CRC校验码
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <param name="dataLength">原始数据长度</param>
        /// <returns>包含CRC的完整数据</returns>
        public static byte[] AppendCrc(byte[] data, int dataLength)
        {
            byte[] result = new byte[dataLength + 2];
            Array.Copy(data, result, dataLength);

            ushort crc = Calculate(data, dataLength);
            result[dataLength] = (byte)(crc & 0xFF);        // CRC低字节
            result[dataLength + 1] = (byte)(crc >> 8);      // CRC高字节

            return result;
        }
    }
}