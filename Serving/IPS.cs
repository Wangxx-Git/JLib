using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace JLib.Serving
{
    public class IPS
    {
        public static string getCityByIP(string ip)
        {

            return ""; 
        }

        //获取客户端IP
        public static string GetClientIP()
        {
            string result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.UserHostAddress;

            return result;
        }


        //根据IP 获取城市 名称

        //url="http://fw.qq.com/ipaddress";  利用QQ上的
        public static string GetWebRequest(string url)
        {
            string cityName = "中山市";
            try
            {
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse webRes = (HttpWebResponse)webReq.GetResponse();
                string resourceCode = "";
                if (webRes.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader reader = new StreamReader(webRes.GetResponseStream(), Encoding.GetEncoding("gb2312"));
                    resourceCode = reader.ReadToEnd();
                    //"var IPData = new Array(\"219.136.64.141\",\"\",\"广东省\",\"广州市\");"

                    int sindex = resourceCode.LastIndexOf(",\"") + 2;
                    string temp = resourceCode.ToString().Substring(sindex);
                    int length = temp.LastIndexOf("\");");
                    cityName = resourceCode.ToString().Substring(sindex, length);
                    reader.Close();
                }
                webRes.Close();
            }
            catch { }

            return cityName;
        }
        
    }
}
