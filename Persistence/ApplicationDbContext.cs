using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PrisonAdministrationSystem.Core.Models;
using PrisonAdministrationSystem.Persistence.EntityConfiguration;

namespace PrisonAdministrationSystem.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Inmate> Inmates { get; set; }
        public DbSet<StaffRole> StaffRoles { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InmateConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}