using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace JLib.Net
{
    public class Computer
    {
        public static string GetClientIp()
        {
            var result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (string.IsNullOrEmpty(result))
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }
    }
}
