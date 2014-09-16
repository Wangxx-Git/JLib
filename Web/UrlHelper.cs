using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JLib.Web
{
    public class UrlHelper
    {
        /// <summary>
        /// 加密URL参数
        /// </summary>
        /// <param name="pram">加密前参数</param>
        /// <returns></returns>
        public static string EncodingUrl(string pram)
        {
            string result = Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(pram)).Replace("+", "%2B");
            return result;
        }

        /// <summary>
        /// 解密URL参数
        /// </summary>
        /// <param name="pram">加密后参数</param>
        /// <returns></returns>
        public static string DecodingUrl(string pram)
        {
            string result = System.Text.Encoding.Default.GetString(Convert.FromBase64String(pram.Replace("%2B", "+")));
            return result;
        }
        
    }
}
