using Autofac;
using Autofac.Features.ResolveAnything;
using SharpGun.Services;

namespace SharpGun.Misc.Allocations
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterSource(
                new AnyConcreteTypeNotAlreadyRegisteredSource(t => t.IsAssignableTo<IHelloAopService>())
            );
        }
    }
}
