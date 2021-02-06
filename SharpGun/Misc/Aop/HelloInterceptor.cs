using System;
using Castle.DynamicProxy;

namespace SharpGun.Misc.Aop
{
    public class HelloInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation) {
            Console.WriteLine("before Hello");
            invocation.Proceed();
            Console.WriteLine("after Hello");
        }
    }
}
