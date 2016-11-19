using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaNet.Core.Logs
{
    public class LogManger : ILogManger
    {
        private log4net.ILog _log = log4net.LogManager.GetLogger("LogManger");

        public void Info(string msg) 
        {
            _log.Info(msg);
        }
        public void Info(string msg, Exception ex)
        {
            _log.Info(msg,ex);
        }

        public void Warn(string msg)
        {
            _log.Warn(msg);
        }
        public void Warn(string msg, Exception ex)
        {
            _log.Warn(msg, ex);            
        }

        public void Error(string msg)
        {
            _log.Error(msg);
        }
        public void Error(string msg, Exception ex)
        {
            _log.Error(msg, ex);
        }
    }
}
