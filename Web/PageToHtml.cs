using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace JLib.Web
{
    public class PageToHtml
    {

        ///   <summary>  
        ///   传入URL返回网页的html代码  
        ///   </summary>  
        ///   <param   name="Url">URL</param>  
        ///   <returns></returns>  
        public static string getHtmlFromUrl(string url, Encoding enc)
        {
            try
            {
                System.Net.WebClient Client = new WebClient();
                Stream strm = Client.OpenRead(url);
                StreamReader sr = new StreamReader(strm, enc);
                string line;
                string html = "";
                while ((line = sr.ReadLine()) != null)
                {
                    html = html + line;
                }
                strm.Close();
                return html;

            }
            catch (WebException exp)
            {
                return "网络访问错误：" + exp.Message + "发生了小错误";
            }
        }
  
    }
}
