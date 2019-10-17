namespace ApiTests.Utilities.Configurations
{
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using log4net;

    public class Log4NetConfiguration
    {
        private readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly XmlDocument log4netConfig = new XmlDocument();

        public void SetLog4NetConfiguration()
        {
            this.log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, this.log4netConfig["log4net"]);
        }
    }
}
