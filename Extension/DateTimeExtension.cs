using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JLib.Extension
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 扩展方法：根据分隔将DateTime转化成标准可识别的格式
        /// </summary>
        /// <param name="dt">要转换的DateTime</param>
        /// <param name="spite">分隔线,默认为："-"</param>
        /// <param name="withTime">是否显示时间</param>
        /// <returns>文件夹的名字</returns>
        public static string ToStdStr(this DateTime dt, bool withTime = false, string spite = "-")
        {
            var res = dt.ToString("yyyy" + spite + "MM" + spite + "dd");
            res += withTime ? " " + dt.ToShortTimeString() : string.Empty;
            return res;
        }
    }
}
