using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBaseFramework
{
    public class Log4NetUtil
    {
        private static readonly ILog LOG = log4net.LogManager.GetLogger("Task");
        public static void log4NetConfiguration()
        {
            FileInfo fi = new FileInfo("../../../Log4J.config");
            Console.WriteLine(fi.FullName);
            log4net.Config.XmlConfigurator.Configure(fi);
            log4net.GlobalContext.Properties["host"]= Environment.MachineName;
        }
    }
}
