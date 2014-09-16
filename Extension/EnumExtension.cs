using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace JLib.Extension
{
    public static class EnumExtension
    {
        /// <summary>
        /// 扩展方法：获取当前枚举的描述
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum temp)
        {
            Type enumType = temp.GetType();
            try
            {
                var fieldInfo = enumType.GetField(temp.ToString());
                var attr =
                    Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute), false) as
                        DescriptionAttribute;
                if (attr != null) return attr.Description;
                return "无枚举描述";

            }
            catch (Exception)
            {
                return "无枚举描述";
            }
        }
    }
}
