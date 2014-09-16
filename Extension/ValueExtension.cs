using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JLib.Extension
{
    public static class ValueExtension
    {
        /// <summary>
        /// 扩展方法：将整形转成有逗号分隔的货币类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUSAMoney(this int value)
        {
            var ts = value.ToString();
            ts = ts.Reverse();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ts.Length; i++)
            {
                sb.Append((i % 3 == 0 && i != 0) ? "," + ts.Substring(i, 1) : ts.Substring(i, 1));
            }

            return sb.ToString().Reverse();
        }
    }
}
