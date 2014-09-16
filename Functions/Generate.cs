using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JLib.Functions
{
    /// <summary>
    /// 生成特定字符类
    /// </summary>
    public class Generate
    {
        /// <summary>
        /// 生成一串随机数字,默认6位，最长32位
        /// </summary>
        /// <param name="length">生成长度</param>
        /// <returns>string</returns>
        public static string GenerateRandomNumber(int length=6)
        {
            string temp = System.Guid.NewGuid().ToString("N");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                if (Convert.ToChar(temp.Substring(i, 1)) > '9')
                {
                    sb.Append(OneRandomNumber());
                }
                else
                {
                    sb.Append(temp.Substring(i, 1));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成一个随机数
        /// </summary>
        /// <returns></returns>
        public static int OneRandomNumber()
        {
            Random rand = new Random();
            int i = rand.Next(10);
            return i;
        }

    }
}
