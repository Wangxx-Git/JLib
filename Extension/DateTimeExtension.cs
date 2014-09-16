using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JLib.Extension
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 扩展方法：根据分隔将DateTime转化成文件夹的名字
        /// </summary>
        /// <param name="dt">要转换的DateTime</param>
        /// <param name="spite">分隔线,默认为："-"</param>
        /// <returns>文件夹的名字</returns>
        public static string ToDirNameString(this DateTime dt, string spite = "-")
        {
            string res = dt.Year + spite + dt.Month + spite + dt.Day;
            return res;
        }
    }
}
