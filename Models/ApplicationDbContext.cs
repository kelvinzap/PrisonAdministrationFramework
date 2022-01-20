﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PrisonAdministrationSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cell> Cells { get; set; }
        public DbSet<Inmate> Inmates { get; set; }

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
            base.OnModelCreating(modelBuilder);

        }
    }
}