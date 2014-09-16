using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Core;

namespace JLib.Tools
{
    [assembly: log4net.Config.XmlConfigurator(Watch = true)]
    public class Logger
    {
        public static ILog Log
        {
            get { return LogManager.GetLogger("Default"); }
        }
    }
}
