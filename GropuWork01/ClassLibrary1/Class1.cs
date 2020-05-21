using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1;

namespace ClassLibrary1
{
    public class Class1
    {
        #region 从16进制转换成字符
        /// <param name="charset”>编码,如"ASCII", "Unicode", "UTF-8", "gb2312"</param>
        public static string UnHex(string hex, string charset)
        {
            try
            {
                if (hex == null) throw new ArgumentNullException("hex");
                hex = hex.Replace(",", "");
                hex = hex.Replace("\n","");
                hex = hex.Replace("\\","");
                hex = hex.Replace(" ", "");
                if (hex.Length % 2 != 0)
                {
                    hex += "20";//空格
                }
                //需要将hex转换成byte数组。
                byte[] bytes = new byte[hex.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    try
                    {
                        //每两个字符是一个 byte o
                        bytes[i] = byte.Parse(hex.Substring(i * 2,2),System.Globalization.NumberStyles.HexNumber);
                    }
                    catch
                    {
                        // Rethrow an exception with custom message.
                        throw new ArgumentException("hex is not a valid hex number!", "hex");
}
                }
                System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
                return chs.GetString(bytes);
            }
            catch (Exception ex)
            {
                Logger.Trace("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "]" + ex.Message);
                return string.Empty;
            }
        }
        #endregion
    }
}
