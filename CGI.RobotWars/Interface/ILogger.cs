using System;

namespace CGI.RobotWars.Interface
{
    public interface ILogger
    {
        void LogFormat(object caller, Level level, string messageFormat, params object[] args);

        void LogErrorFormat(Type type, string message, params object[] arguments);

        void LogWarningFormat(Type type, string message, params object[] arguments);

        void LogInfoFormat(Type type, string message, params object[] arguments);

        void LogDebugFormat(Type type, string message, params object[] arguments);
    }
}