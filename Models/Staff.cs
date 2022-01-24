using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrisonAdministrationSystem.Models
{
    public class Staff
    {
        public string Id { get; set; }
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
        public string Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public byte RoleId { get; set; }

        public StaffRole Role { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public string BirthCity { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public int Weight { get; set; }

        [Required]
        public string Passport { get; set; }
        [Required]
        public long BankVerificationNumber { get; set; }
        [Required]
        public DateTime DateOfCreation { get; private set; }

        public Staff()
        {
            Id = Guid.NewGuid().ToString();
            DateOfCreation = DateTime.Now;
        }
    }
}