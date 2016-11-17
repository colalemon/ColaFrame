using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;


namespace ColaNet.Core.Module
{
    public  class ColaModule
    {
        private IocManger _ioc;
        public ColaModule() 
        {
            _ioc = new IocManger();
        }

        public IContainer Register()
        {
            return _ioc.Register();
        }
    }
}
