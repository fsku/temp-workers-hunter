using TemporaryWorkersHunter.Entities.DbContexts;

namespace TemporaryWorkersHunter.Entities.DataContexts.TemporaryWorkersMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TemporaryWorkersDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\TemporaryWorkersMigrations";
            ContextKey = "TemporaryWorkersHunter.Entities.DbContexts.TemporaryWorkersDb";
            
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
