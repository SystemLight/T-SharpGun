using System;

namespace SharpGun.Services
{
    public interface IAutofacTrialServiceA
    {
        public void SayHello();
    }

    public class AutofacTrialServiceA : IAutofacTrialServiceA
    {
        public void SayHello() {
            Console.WriteLine("Hello");
        }
    }

    public interface IAutofacTrialServiceB
    {
        public void SayHello();
    }

    public class AutofacTrialServiceB : IAutofacTrialServiceB
    {
        public IAutofacTrialServiceA ServiceA { get; set; }

        public void SayHello() {
            ServiceA.SayHello();
        }
    }

    public interface IAutofacTrialServiceC
    {
        public void SayHello();
    }

    public class AutofacTrialServiceC : IAutofacTrialServiceC
    {
        public IAutofacTrialServiceA ServiceA { get; set; }

        public void SetService(IAutofacTrialServiceA serviceA) {
            ServiceA = serviceA;
        }

        public void SayHello() {
            ServiceA.SayHello();
        }
    }
}
