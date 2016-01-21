using System.Reflection;
using Autofac;

namespace TemporaryWorkersHunter.Web.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("TemporaryWorkersHunter.Service"))
                      .Where(t => t.Name.EndsWith("Service"))
                      .AsImplementedInterfaces()
                      .InstancePerLifetimeScope();
        }
    }
}