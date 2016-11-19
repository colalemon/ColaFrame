using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColaNet.Core.Logs;

namespace ColaNet.Core.BaseService
{
    public abstract class ColaBaseService
    {
        public ILogManger logManger { get; set; }
        public ColaBaseService() 
        {
            logManger = new LogManger();
        }
    }
}
