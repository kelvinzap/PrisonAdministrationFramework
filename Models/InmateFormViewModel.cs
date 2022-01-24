using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrisonAdministrationSystem.Models
{
    public class InmateFormViewModel
    {

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
        [FutureDate(ErrorMessage = "The Date Format is invalid! Format: 2 Jan 2022")]

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
        [FutureDate(ErrorMessage = "The Date Format is invalid! Format: 2 Jan 2022")]
        public string DateOfIncarceration { get; set; }
        [Required]
        [ValidTime(ErrorMessage = "The Time Format is invalid! Format: 16:00")]
        public string TimeOfIncarceration { get; set; }
        public string DateOfRelease { get; set; }
        [Required]
        public HttpPostedFileBase FrontProfile { get; set; }
        [Required]

        public HttpPostedFileBase SideProfile { get; set; }

        public IEnumerable<Cell> Cells { get; set; }

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