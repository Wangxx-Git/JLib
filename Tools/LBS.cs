using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JLib.Tools
{
    /// <summary>
    /// 百度IP定位
    /// </summary>
    public class LBS
    {
        /// <summary>
        /// 根据ip获取地址长串
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetJson(string ip) 
        {
            var url = "http://api.map.baidu.com/location/ip?ak=F454f8a5efe5e577997931cc01de3974&ip=" + ip + "&coor=bd09l";
            var wc = new System.Net.WebClient {Encoding = Encoding.UTF8};
            return wc.UploadString(url, "");
        }
    }
}
