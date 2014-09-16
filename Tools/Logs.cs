using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace JLib.Tools
{
    public class Logs
    {
        public static string Path = HttpContext.Current.Server.MapPath("log.txt");

        /// <summary>
        /// 追加日志    
        /// </summary>
        /// <param name="str"></param>
        public static void AppendLog(string str)
        {
            StreamWriter sw = new StreamWriter(Path,true);
            sw.Write(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + str + "\r\n");
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
    }
}
