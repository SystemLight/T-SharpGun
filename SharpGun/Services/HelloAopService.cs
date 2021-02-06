using System;
using Autofac.Extras.DynamicProxy;
using SharpGun.Misc.Aop;

namespace SharpGun.Services
{
    [Intercept(typeof(HelloInterceptor))]
    public interface IHelloAopService
    {
        public void SayHello();
    }

    public class HelloAopService : IHelloAopService
    {
        public void SayHello() {
            Console.WriteLine("hello");
        }
    }
}
