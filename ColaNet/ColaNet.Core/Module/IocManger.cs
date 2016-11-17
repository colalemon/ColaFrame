using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColaNet.Core.Repositories;
using Autofac.Integration.Mvc;



namespace ColaNet.Core.Module
{
    public class IocManger
    {
        public IocManger()
        {

        }
        public IContainer Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)); //仓储注入
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            var baseType = typeof(IDependency);
            var assembly = AppDomain.CurrentDomain.GetAssemblies().ToList();


            builder.RegisterControllers(assembly.ToArray()); //注册所有控制器
            builder.RegisterAssemblyTypes(assembly.ToArray()).Where(t => baseType.IsAssignableFrom(t) && t != baseType).AsImplementedInterfaces().InstancePerLifetimeScope();
            var container = builder.Build();
            

            return container;
           
        }

    }
}
