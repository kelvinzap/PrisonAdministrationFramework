using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrisonAdministrationSystem.Models
{
    public class Inmate
    {
        [StringLength(255)]
        public string Id { get; private set; }

        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]

        public string MiddleName { get; set; }
        [StringLength(100)]

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        [StringLength(15)]

        public string Gender { get; set; }

       
        public Cell Cell { get; set; }
        [Required]
        public int CellId { get; set; }
        [Required]
        public string Offense { get; set; }
        [Required]
        [StringLength(30)]
        public string Sentence { get; set; }
        
        public string Remission { get; set; }
        [Required]

        public DateTime DateOfIncarceration { get; set; }
      
        public string DateOfRelease { get; private set; }
       
        [Required]

        public string FrontProfile { get; set; }
        [Required]
        public string SideProfile { get; set; }
        public bool HasLeft { get; private set; }
        public Inmate()
        {
            this.Id = Guid.NewGuid().ToString();

        }

        public void GetDateOfRelease()
        {
            var values = new[] { "Life", "life", "live", "Live", "Death", "death" };
            var str =Sentence;
            //checking if the sentence contains any of the values above
            if (values.Any(str.Contains))
            {
                DateOfRelease = "";
                return;
            }
            var date = Sentence;
            date = date.ToLower();
            if (date.Contains("year"))
            {
               var result = new string(Convert.ToString(date).Where(c => char.IsDigit(c)).ToArray());
                DateOfRelease = DateOfIncarceration.AddYears(Convert.ToInt32(result)).ToString("d MMM yyyy");
            }
            
            
            if (date.Contains("month"))
            {
                var result = new string(Convert.ToString(date).Where(c => char.IsDigit(c)).ToArray());
                DateOfRelease = DateOfIncarceration.AddMonths(Convert.ToInt32(result)).ToString("d MMM yyyy");
            }

            if (date.Contains("day"))
            {
                var result = new string(Convert.ToString(date).Where(c => char.IsDigit(c)).ToArray());
                DateOfRelease = DateOfIncarceration.AddDays(Convert.ToDouble(result)).ToString("d MMM yyyy");
            }
        }
        public void GetRemissionDateOfRelease(string date)
        {
            if(date == null)
                return;
            date = date.ToLower();
            if(date.Contains("years"))
            {
              date =   date.Replace("years", "");
                var dateTime = DateTime.Parse(DateOfRelease).AddYears(-Convert.ToInt32(date));
                DateOfRelease = dateTime.ToString();

            }
            if (date.Contains("months"))
            {
              date =   date.Replace("months", "");
              var dateTime = DateTime.Parse(DateOfRelease).AddMonths(Convert.ToInt32(date));
              DateOfRelease = dateTime.ToString();

            }

            if (date.Contains("days"))
            {
              date =   date.Replace("days", "");

              var dateTime = DateTime.Parse(DateOfRelease).AddDays(-Convert.ToInt32(date));
              DateOfRelease = dateTime.ToString();
            }

            
        }

        public void Remove()
        {
            HasLeft = true;
        }

        public void Modify(InmateFormViewModel model)
        {
            MiddleName = model.MiddleName;
            LastName = model.LastName;
            FirstName = model.FirstName;
            Gender = model.Gender;
            CellId = model.Cell;
            Sentence = model.Sentence;
            DateOfBirth = model.GetAge();
            Offense = model.Offense;
            DateOfIncarceration = model.GetDateTime();
            this.GetDateOfRelease();
        }
    }
}