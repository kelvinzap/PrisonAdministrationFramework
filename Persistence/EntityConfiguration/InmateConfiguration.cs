using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using PrisonAdministrationFramework.Core.Models;

namespace PrisonAdministrationFramework.Persistence.EntityConfiguration
{
    public class InmateConfiguration : EntityTypeConfiguration<Inmate>
    {
        public InmateConfiguration()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasMaxLength(255);

            Property(p => p.FirstName)
                .HasMaxLength(100);
            
            Property(p => p.LastName)
                .HasMaxLength(100);
            
            Property(p => p.MiddleName)
                .HasMaxLength(100);
            
            Property(p => p.Gender)
                .HasMaxLength(15);

            Property(p => p.CellId)
                .IsRequired();

            Property(p => p.Offense)
                .IsRequired();
            Property(p => p.Sentence)
                .IsRequired()
                .HasMaxLength(30);

            Property(p => p.DateOfIncarceration)
                .IsRequired();

            Property(p => p.FrontProfile)
                .IsRequired();

            Property(p => p.SideProfile)
                .IsRequired();

            Property(p => p.Complexion)
                .IsRequired();

            Property(p => p.Height)
                .IsRequired();

            Property(p => p.Weight)
                .IsRequired();

            Property(p => p.BirthCity)
                .IsRequired();

            Property(p => p.Nationality)
                .IsRequired();
            
            Property(i => i.DateOfRelease)
                .IsOptional();
            
            Property(i => i.BankVerificationNumber)
                .IsOptional();

            Property(i => i.IdentificationNumber)
                .IsOptional();
        }
    }
}