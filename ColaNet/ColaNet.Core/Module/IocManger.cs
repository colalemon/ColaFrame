using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColaNet.Core.Repositories;
using Autofac.Integration.Mvc;
using ColaNet.Core.Logs;
using System.Reflection;
using System.Web.Compilation;
using Autofac.Extras.DynamicProxy;
using ColaNet.Core.Interceptor;




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

            builder.RegisterType<AopIntercept>(); //拦截器注入

            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).EnableInterfaceInterceptors(); //仓储注入
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).EnableInterfaceInterceptors();

            var baseType = typeof(IDependency);
            var assembly = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();
            builder.RegisterControllers(assembly.ToArray()); //注册所有控制器
            builder.RegisterAssemblyTypes(assembly.ToArray()).Where(t => baseType.IsAssignableFrom(t) && t != baseType).EnableInterfaceInterceptors().AsImplementedInterfaces().InstancePerLifetimeScope(); //注册所有依赖的IDependency
            var container = builder.Build();


            return container;

        }

    }
}
