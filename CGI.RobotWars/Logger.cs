using System;
using CGI.RobotWars.Interface;
using log4net;

namespace CGI.RobotWars
{
    public class Logger : ILogger
    {
        public void LogFormat(object caller, Level level, string messageFormat, params object[] args)
        {
            LogFormat(caller.GetType(), level, messageFormat, args);
        }

        public void LogFormat(Type type, Level level, string messageFormat, params object[] args)
        {
            switch (level)
            {
                case Level.Debug:
                    LogDebugFormat(type, messageFormat, args);
                    break;
                case Level.Error:
                    LogErrorFormat(type, messageFormat, args);
                    break;
                case Level.Info:
                    LogInfoFormat(type, messageFormat, args);
                    break;
                case Level.Warning:
                    LogWarningFormat(type, messageFormat, args);
                    break;
            }
        }

        public void LogWarningFormat(Type type, string message, params object[] arguments)
        {
            ILog logger = GetLogger(type);
            if (logger.IsWarnEnabled)
            {
                logger.WarnFormat(message, arguments);
            }
        }


        public void LogDebugFormat(Type type, string message, params object[] arguments)
        {
            ILog logger = GetLogger(type);
            if (logger.IsDebugEnabled)
            {
                logger.DebugFormat(message, arguments);
            }
        }

        public void LogErrorFormat(Type type, string message, params object[] arguments)
        {
            ILog logger = GetLogger(type);
            if (logger.IsErrorEnabled)
            {
                logger.ErrorFormat(message, arguments);
            }
        }

        public void LogInfoFormat(Type type, string message, params object[] arguments)
        {
            ILog logger = GetLogger(type);
            if (logger.IsInfoEnabled)
            {
                logger.InfoFormat(message, arguments);
            }
        }

        private static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }


    }
}