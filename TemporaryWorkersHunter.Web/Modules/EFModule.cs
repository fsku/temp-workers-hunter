using System.Data.Entity;
using Autofac;
using TemporaryWorkersHunter.Entities.DbContexts;
using TemporaryWorkersHunter.Repository.Common;

namespace TemporaryWorkersHunter.Web.Modules
{
    public class EfModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(TemporaryWorkersDb)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();

        }

    }
}