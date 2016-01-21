using System.Data.Entity.Migrations;
using TemporaryWorkersHunter.Entities.DbContexts;

namespace TemporaryWorkersHunter.Web.DataContexts.TemporaryWorkersMigrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TemporaryWorkersDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\TemporaryWorkersMigrations";
        }

        protected override void Seed(TemporaryWorkersDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
