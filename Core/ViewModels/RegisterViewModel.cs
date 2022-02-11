using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using PrisonAdministrationSystem.Core.Models;
using PrisonAdministrationSystem.Core.Validations;

namespace PrisonAdministrationSystem.Core.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]

        [StringLength(100)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(100)]
        public string MaidenName { get; set; }
    
        
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [Range(10000000000, 99999999999)]

        public long IdentificationNumber { get; set; }
        
        [Required]
        [Range(10000000000, 99999999999)]

        public long BankVerificationNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Gender { get; set; }
        //d/m/y
        [Required]
        [CorrectDate(ErrorMessage = "The Date Format is invalid! Format: 2 Jan 2022")]

        public string DateOfBirth { get; set; }
        [Required]
        [StringLength(100)]
        public string Nationality { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string BirthCity { get; set; }
        [Required]
        [StringLength(100)]
        public string MaritalStatus { get; set; }

        public IEnumerable<MarritalStatus> StatusOptions { get; set; }
        [Required]
        [Range(100,250)]
        public int Height { get; set; }
        [Required]
        [Range(70,1000)]
        public int Weight { get; set; }
        [Required]
        public HttpPostedFileBase Passport { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime GetDateOfBirth()
        {
            return DateTime.Parse(DateOfBirth);
        }
    }
}