using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PrisonAdministrationSystem.Models
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
            modelBuilder.Entity<Inmate>()
                .Property(i => i.Id)
                .IsRequired();
            
            modelBuilder.Entity<Inmate>()
                .Property(i => i.DateOfRelease)
                .IsOptional();
            
            modelBuilder.Entity<Inmate>()
                .Property(i => i.BankVerificationNumber)
                .IsOptional();
            
            modelBuilder.Entity<Inmate>()
                .Property(i => i.IdentificationNumber)
                .IsOptional();
            base.OnModelCreating(modelBuilder);

        }
    }
}