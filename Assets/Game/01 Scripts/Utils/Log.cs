namespace Hajime
{
    public enum LogLevel : byte
    {
        Debug,
        Info,
        Warning,
        Error,
    }

    public static class Log
    {
        private const string logInfoFormat = "<color=#00FF00>{0}</color>";
        private const string logWarningFormat = "<color=#FFFF00>{0}</color>";
        private const string logErrorFormat = "<color=#FF0000>{0}</color>";
        private static LogLevel logLevel = LogLevel.Debug;
        private static bool debugEnabled = true;
        private static bool infoEnabled = true;
        private static bool warningEnabled = true;
        private static bool errorEnabled = true;

        public static LogLevel LogLevel => logLevel;
        public static bool DebugEnabled => debugEnabled;
        public static bool InfoEnabled => infoEnabled;
        public static bool WarningEnabled => warningEnabled;
        public static bool ErrorEnabled => errorEnabled;

        public static void SetLogLevel(LogLevel logLevel)
        {
            Log.logLevel = logLevel;

            switch (logLevel)
            {
                case LogLevel.Debug:
                    debugEnabled = true;
                    infoEnabled = true;
                    warningEnabled = true;
                    errorEnabled = true;
                    break;
                case LogLevel.Info:
                    debugEnabled = false;
                    infoEnabled = true;
                    warningEnabled = true;
                    errorEnabled = true;
                    break;
                case LogLevel.Warning:
                    debugEnabled = false;
                    infoEnabled = false;
                    warningEnabled = true;
                    errorEnabled = true;
                    break;
                case LogLevel.Error:
                    debugEnabled = false;
                    infoEnabled = false;
                    warningEnabled = false;
                    errorEnabled = true;
                    break;
                default:
                    break;
            }
        }

        public static void EnableDebug(bool enable) => debugEnabled = enable;
        public static void EnableInfo(bool enable) => infoEnabled = enable;
        public static void EnableWarning(bool enable) => warningEnabled = enable;
        public static void EnableError(bool enable) => errorEnabled = enable;

        public static void Debug(string message)
        {
            if (DebugEnabled) LogMessage(LogLevel.Debug, message);
        }

        public static void Debug<T>(string format, T arg)
        {
            if (DebugEnabled) LogMessage(LogLevel.Debug, string.Format(format, arg));
        }

        public static void Debug<T1, T2>(string format, T1 arg1, T2 arg2)
        {
            if (DebugEnabled) LogMessage(LogLevel.Debug, string.Format(format, arg1, arg2));
        }

        public static void Debug<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
        {
            if (DebugEnabled) LogMessage(LogLevel.Debug, string.Format(format, arg1, arg2, arg3));
        }

        public static void Debug(string format, params object[] args)
        {
            if (DebugEnabled) LogMessage(LogLevel.Debug, string.Format(format, args));
        }

        public static void Info(string message)
        {
            if (InfoEnabled) LogMessage(LogLevel.Info, message);
        }

        public static void Info<T>(string format, T arg)
        {
            if (InfoEnabled) LogMessage(LogLevel.Info, string.Format(format, arg));
        }

        public static void Info<T1, T2>(string format, T1 arg1, T2 arg2)
        {
            if (InfoEnabled) LogMessage(LogLevel.Info, string.Format(format, arg1, arg2));
        }

        public static void Info<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
        {
            if (InfoEnabled) LogMessage(LogLevel.Info, string.Format(format, arg1, arg2, arg3));
        }

        public static void Info(string format, params object[] args)
        {
            if (InfoEnabled) LogMessage(LogLevel.Info, string.Format(format, args));
        }

        public static void Warning(string message)
        {
            if (WarningEnabled) LogMessage(LogLevel.Warning, message);
        }

        public static void Warning<T>(string format, T arg)
        {
            if (WarningEnabled) LogMessage(LogLevel.Warning, string.Format(format, arg));
        }

        public static void Warning<T1, T2>(string format, T1 arg1, T2 arg2)
        {
            if (WarningEnabled) LogMessage(LogLevel.Warning, string.Format(format, arg1, arg2));
        }

        public static void Warning<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
        {
            if (WarningEnabled) LogMessage(LogLevel.Warning, string.Format(format, arg1, arg2, arg3));
        }

        public static void Warning(string format, params object[] args)
        {
            if (WarningEnabled) LogMessage(LogLevel.Warning, string.Format(format, args));
        }

        public static void Error(string message)
        {
            if (ErrorEnabled) LogMessage(LogLevel.Error, message);
        }

        public static void Error<T>(string format, T arg)
        {
            if (ErrorEnabled) LogMessage(LogLevel.Error, string.Format(format, arg));
        }

        public static void Error<T1, T2>(string format, T1 arg1, T2 arg2)
        {
            if (ErrorEnabled) LogMessage(LogLevel.Error, string.Format(format, arg1, arg2));
        }

        public static void Error<T1, T2, T3>(string format, T1 arg1, T2 arg2, T3 arg3)
        {
            if (ErrorEnabled) LogMessage(LogLevel.Error, string.Format(format, arg1, arg2, arg3));
        }

        public static void Error(string format, params object[] args)
        {
            if (ErrorEnabled) LogMessage(LogLevel.Error, string.Format(format, args));
        }

        public static void Exception(System.Exception exception)
        {
            if (ErrorEnabled)
            {
                LogMessage(LogLevel.Error, exception.Message);
                LogMessage(LogLevel.Error, exception.StackTrace);
            }
        }

        private static void LogMessage(LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    UnityEngine.Debug.Log(message);
                    break;

                case LogLevel.Info:
                    UnityEngine.Debug.Log(string.Format(logInfoFormat, message));
                    break;

                case LogLevel.Warning:
                    UnityEngine.Debug.LogWarning(string.Format(logWarningFormat, message));
                    break;

                case LogLevel.Error:
                    UnityEngine.Debug.LogError(string.Format(logErrorFormat, message));
                    break;
            }
        }
    }

}