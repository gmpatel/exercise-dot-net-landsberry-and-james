using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnualLeave.Logging.Core;
using log4net;

namespace AnnualLeave.Logging
{
    public class Logger : ILogger
    {
        private static volatile ILogger instance;
        private static ILog logger = null;

        private static readonly object ConsturctorLock = new Object();

        private readonly object syncLock = new Object();

        private Logger()
        {
            if (logger == null)
            {
                logger =
                    LogManager
                    .GetLogger("Log4Net");

                log4net
                    .Config
                    .XmlConfigurator
                    .Configure();
            }
        }

        public static ILogger Instance()
        {
            if (instance == null)
            {
                lock (ConsturctorLock)
                {
                    if (instance == null) instance = new Logger();
                }
            }

            return instance;
        }

        private static string GetCallerInfo()
        {
            var stackFrames = new StackTrace().GetFrames();

            if (stackFrames != null)
            {
                var method = stackFrames[2].GetMethod();

                if (method.DeclaringType != null)

                    return string.Format(">> Method = {0}(), Class Name = {1}, Full Name = {2} <<", method.Name, method.DeclaringType.Name,
                        method.DeclaringType.FullName);
            }

            return string.Empty;
        }

        public void Debug(object message, Exception exception)
        {
            lock (syncLock)
            {
                if (IsDebugEnabled)
                    logger.Debug(string.Format("{0} {1}", GetCallerInfo(), message), exception);
            }
        }

        public void Debug(object message)
        {
            lock (syncLock)
            {
                if (IsDebugEnabled)
                    logger.Debug(string.Format("{0} {1}", GetCallerInfo(), message));
            }
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            lock (syncLock)
            {
                if (IsDebugEnabled)
                    logger.DebugFormat(provider, format, args);
            }
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            lock (syncLock)
            {
                if (IsDebugEnabled)
                    logger.DebugFormat(format, arg0, arg1, arg2);
            }
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            lock (syncLock)
            {
                if (IsDebugEnabled)
                    logger.DebugFormat(format, arg0, arg1);
            }
        }

        public void DebugFormat(string format, object arg0)
        {
            lock (syncLock)
            {
                if (IsDebugEnabled)
                    logger.DebugFormat(format, arg0);
            }
        }

        public void DebugFormat(string format, params object[] args)
        {
            lock (syncLock)
            {
                if (IsDebugEnabled)
                    logger.DebugFormat(format, args);
            }
        }

        public void Error(object message, Exception exception)
        {
            lock (syncLock)
            {
                if (IsErrorEnabled)
                    logger.Error(string.Format("{0} {1}", GetCallerInfo(), message), exception);
            }
        }

        public void Error(object message)
        {
            lock (syncLock)
            {
                if (IsErrorEnabled)
                    logger.Error(string.Format("{0} {1}", GetCallerInfo(), message));
            }
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            lock (syncLock)
            {
                if (IsErrorEnabled)
                    logger.ErrorFormat(provider, format, args);
            }
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            lock (syncLock)
            {
                if (IsErrorEnabled)
                    logger.ErrorFormat(format, arg0, arg1, arg2);
            }
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            lock (syncLock)
            {
                if (IsErrorEnabled)
                    logger.ErrorFormat(format, arg0, arg1);
            }
        }

        public void ErrorFormat(string format, object arg0)
        {
            lock (syncLock)
            {
                if (IsErrorEnabled)
                    logger.ErrorFormat(format, arg0);
            }
        }

        public void ErrorFormat(string format, params object[] args)
        {
            lock (syncLock)
            {
                if (IsErrorEnabled)
                    logger.ErrorFormat(format, args);
            }
        }

        public void Fatal(object message, Exception exception)
        {
            lock (syncLock)
            {
                if (IsFatalEnabled)
                    logger.Fatal(string.Format("{0} {1}", GetCallerInfo(), message), exception);
            }
        }

        public void Fatal(object message)
        {
            lock (syncLock)
            {
                if (IsFatalEnabled)
                    logger.Fatal(string.Format("{0} {1}", GetCallerInfo(), message));
            }
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            lock (syncLock)
            {
                if (IsFatalEnabled)
                    logger.FatalFormat(provider, format, args);
            }
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            lock (syncLock)
            {
                if (IsFatalEnabled)
                    logger.FatalFormat(format, arg0, arg1, arg2);
            }
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            lock (syncLock)
            {
                if (IsFatalEnabled)
                    logger.FatalFormat(format, arg0, arg1);
            }
        }

        public void FatalFormat(string format, object arg0)
        {
            lock (syncLock)
            {
                if (IsFatalEnabled)
                    logger.FatalFormat(format, arg0);
            }
        }

        public void FatalFormat(string format, params object[] args)
        {
            lock (syncLock)
            {
                if (IsFatalEnabled)
                    logger.FatalFormat(format, args);
            }
        }

        public void Info(object message, Exception exception)
        {
            lock (syncLock)
            {
                if (IsInfoEnabled)
                    logger.Info(string.Format("{0} {1}", GetCallerInfo(), message), exception);
            }
        }

        public void Info(object message)
        {
            lock (syncLock)
            {
                if (IsInfoEnabled)
                    logger.Info(string.Format("{0} {1}", GetCallerInfo(), message));
            }
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            lock (syncLock)
            {
                if (IsInfoEnabled)
                    logger.InfoFormat(provider, format, args);
            }
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            lock (syncLock)
            {
                if (IsInfoEnabled)
                    logger.InfoFormat(format, arg0, arg1, arg2);
            }
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            lock (syncLock)
            {
                if (IsInfoEnabled)
                    logger.InfoFormat(format, arg0, arg1);
            }
        }

        public void InfoFormat(string format, object arg0)
        {
            lock (syncLock)
            {
                if (IsInfoEnabled)
                    logger.InfoFormat(format, arg0);
            }
        }

        public void InfoFormat(string format, params object[] args)
        {
            lock (syncLock)
            {
                if (IsInfoEnabled)
                    logger.InfoFormat(format, args);
            }
        }

        public bool IsDebugEnabled
        {
            get { return logger.IsDebugEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return logger.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return logger.IsFatalEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return logger.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return logger.IsWarnEnabled; }
        }

        public void Warn(object message, Exception exception)
        {
            lock (syncLock)
            {
                if (IsWarnEnabled)
                    logger.Warn(string.Format("{0} {1}", GetCallerInfo(), message), exception);
            }
        }

        public void Warn(object message)
        {
            lock (syncLock)
            {
                if (IsWarnEnabled)
                    logger.Warn(string.Format("{0} {1}", GetCallerInfo(), message));
            }
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            lock (syncLock)
            {
                if (IsWarnEnabled)
                    logger.WarnFormat(provider, format, args);
            }
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            lock (syncLock)
            {
                if (IsWarnEnabled)
                    logger.WarnFormat(format, arg0, arg1, arg2);
            }
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            lock (syncLock)
            {
                if (IsWarnEnabled)
                    logger.WarnFormat(format, arg0, arg1);
            }
        }

        public void WarnFormat(string format, object arg0)
        {
            lock (syncLock)
            {
                if (IsWarnEnabled)
                    logger.WarnFormat(format, arg0);
            }
        }

        public void WarnFormat(string format, params object[] args)
        {
            lock (syncLock)
            {
                if (IsWarnEnabled)
                    logger.WarnFormat(format, args);
            }
        }
    }
}