namespace ApiTests.Utilities
{
    using System.Reflection;
    using ApiTests.Utilities.Configurations;
    using log4net;

    public static class Logger
    {
        public static ILog Initialize()
        {
            new Log4NetConfiguration().SetLog4NetConfiguration();
            return LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}
