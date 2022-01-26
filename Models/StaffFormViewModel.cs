using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PrisonAdministrationSystem.Controllers;
using PrisonAdministrationSystem.Validations;

namespace PrisonAdministrationSystem.Models
{
    public class StaffFormViewModel
    {
        public  string Id { get; set; }
        public string Heading { get; set; }
        
        public IEnumerable<MarritalStatus> StatusOptions { get; set; }
        public IEnumerable<StaffRole> StaffRoles { get; set; }
        public byte RoleId { get; set; }
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

        [Required]
        [Range(100, 250)]
        public int Height { get; set; }
        [Required]
        [Range(70, 1000)]
        public int Weight { get; set; }
        [CustomRequired(ConditionId = "Id")]
        public HttpPostedFileBase Passport { get; set; }
        public string Action
        {
            get
            {
               Expression<Func<StaffController, ActionResult>> create = (c => c.CreateStaff(this));
               Expression<Func<StaffController, ActionResult>> update = (c => c.Update(this));
               var action = (Id != null) ? update : create;
               return (action.Body as MethodCallExpression).Method.Name;
            }
        }
        
        public DateTime GetDateOfBirth()
        {
            return DateTime.Parse(DateOfBirth);
        }
    }
}