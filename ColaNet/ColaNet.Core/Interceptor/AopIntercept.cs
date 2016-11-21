using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaNet.Core.Interceptor
{
    public class AopIntercept : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();

            if (invocation.Method.Name == "Add")
            {
                //throw new Exception();
            }
        }
    }
}
