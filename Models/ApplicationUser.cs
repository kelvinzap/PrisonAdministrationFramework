using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PrisonAdministrationSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string MiddleName { get; set; }
        [Required]
        public string MaidenName { get; set; }
        [Required]
        public long IdentificationNumber { get; set; }
        [Required]
        public string  Gender { get; set; }
        //d/m/y
        [Required]
        public string  DateOfBirth { get; set; }
        [Required]
        public string  Nationality { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public string BirthCity{ get; set; }
        [Required]
        public string MaritalStatus{ get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Weight { get; set; }

        [Required]
        public string Passport { get; set; }
        [Required]
        public long BankVerificationNumber { get; set; }
        [Required]
        public DateTime DateOfCreation { get;private set; }

        public ApplicationUser()
        {
         DateOfCreation = DateTime.Now;   
        }

       
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}