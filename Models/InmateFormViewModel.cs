using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using PrisonAdministrationSystem.Controllers;
using PrisonAdministrationSystem.Validations;

namespace PrisonAdministrationSystem.Models
{
    public class InmateFormViewModel
    {
        public string Id { get; set; }
        public string Heading { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]

        public string MiddleName { get; set; }
        [Required]
        [StringLength(100)]

        public string LastName { get; set; }
        [Required]
        [CorrectDate(ErrorMessage = "The Date Format is invalid! Format: 2 Jan 2022")]

        public string DateOfBirth { get; set; }
        [StringLength(15)]

        public string Gender { get; set; }
       
        [Required]
        public int Cell { get; set; }
        [Required]
        public string Offense { get; set; }
        [Required]
        [StringLength(30)]
        [CorrectSentence(ErrorMessage = "Invalid Sentence")]
        public string Sentence { get; set; }
      
        [Required]
        [CorrectDate(ErrorMessage = "The Date Format is invalid! Format: 2 Jan 2022")]
        public string DateOfIncarceration { get; set; }
        [Required]
        [ValidTime(ErrorMessage = "The Time Format is invalid! Format: 16:00")]
        public string TimeOfIncarceration { get; set; }
        public string DateOfRelease { get; set; }
        [FrontProfileRequired(ConditionId = "Id")]
        public HttpPostedFileBase FrontProfile { get; set; }
        [SideProfileRequired(ConditionId = "Id")]
        public HttpPostedFileBase SideProfile { get; set; }

        public long IdentificationNumber { get; set; }


        public long BankVerificationNumber { get; set; }
        [Required]
        [Range(100, 250)]
        public int Height { get; set; }
        [Required]
        [Range(70, 1000)]
        public int Weight { get; set; }
        [Required]
        [StringLength(100)]
        public string Nationality { get; set; }
        [Required]
        [StringLength(100)]
        public string BirthCity { get; set; }
        [Required]
        [StringLength(25)]
        public string Complexion { get; set; }

        public string Action
        {
            get
            {
               Expression<Func<InmateController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<InmateController, ActionResult>> create = c => c.Create(this);
                var action = (Id != null) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public IEnumerable<Cell> Cells { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", DateOfIncarceration, TimeOfIncarceration));

        }    
        
        public DateTime GetAge()
        {
            return DateTime.Parse(DateOfBirth);

        }    
        
       
    }
}