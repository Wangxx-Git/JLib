using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace JLib.Win
{
    public class AppConfigHelper
    {
        /// <summary>
        /// WinForm更新App.config中，key对应的value，没有则添加
        /// </summary>
        /// <param name="appKey">key</param>
        /// <param name="appValue">value</param>
        public static void SetValue(string appKey, string appValue)
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
