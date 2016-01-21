using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TemporaryWorkersHunter.Entities.Models;

namespace TemporaryWorkersHunter.Entities.DbContexts
{

    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.HasDefaultSchema("Identity");
            base.OnModelCreating(modelBuilder);
        }

        public static IdentityDb Create()
        {
            return new IdentityDb();
        }
    }


}
