using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JLib.IO
{
    public class FileOperation
    {
        /// <summary>
        /// 获取文件全部文本内容
        /// </summary>
        /// <param name="path">文件绝对路径</param>
        /// <param name="en">编码方式</param>
        /// <returns></returns>
        public static string GetTxtToEnd(string path, Encoding en)
        {
            var fs = new FileStream(path, FileMode.Open);
            var sr = new StreamReader(fs, en);
            var res = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            return res;
        }

        /// <summary>
        /// 向文本文件里面写内容
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="txt">文本内容</param>
        /// <param name="en">编码方式</param>
        public static void SetTxt(string path, string txt, Encoding en)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, en);
            sw.Write(txt);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

    }
}
