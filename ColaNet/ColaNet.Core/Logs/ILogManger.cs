using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaNet.Core.Logs
{
    public interface ILogManger
    {
        void Info(string msg);
        void Info(string msg,Exception ex);
        void Warn(string msg);
        void Warn(string msg, Exception ex);

        void Error(string msg);
        void Error(string msg, Exception ex);
    }
}
