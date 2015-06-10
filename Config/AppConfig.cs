using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace JLib.Config
{
    public class AppConfig
    {
        /// <summary>
        /// 根据name获取value
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetByName(string name)
        {
            var temp = ConfigurationManager.AppSettings[name];
            return string.IsNullOrEmpty(temp) ? "" : temp;
        }

        /// <summary>
        /// 根据name获取连接字符
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetConnectionStrByName(string name)
        {
            var temp = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return string.IsNullOrEmpty(temp) ? "" : temp;
        }

        /// <summary>
        /// WinForm更新App.config中，key对应的value，没有则添加
        /// </summary>
        /// <param name="appKey">key</param>
        /// <param name="appValue">value</param>
        public static void AddOrUpdate(string appKey, string appValue)
        {
            var xDoc = new System.Xml.XmlDocument();
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");

            var xNode = xDoc.SelectSingleNode("//appSettings");
            if (xNode != null)
            {
                var xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + appKey + "']");
                if (xElem1 != null) xElem1.SetAttribute("value", appValue);
                else
                {
                    var xElem2 = xDoc.CreateElement("add");
                    xElem2.SetAttribute("key", appKey);
                    xElem2.SetAttribute("value", appValue);
                    xNode.AppendChild(xElem2);
                }
            }
            xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
        }

    }
}
