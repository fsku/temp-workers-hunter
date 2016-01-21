using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Entities.DbContexts
{
    public class TemporaryWorkersDb : DbContext
    {

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<RecruitmentAgency> RecruitmentAgencies { get; set; }

        public TemporaryWorkersDb() : base("DefaultConnection")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("Identity");
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }

        public System.Data.Entity.DbSet<TemporaryWorkersHunter.Entities.OrderRow> OrderRows { get; set; }
    }
}
