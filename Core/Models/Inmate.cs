using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using Grpc.Core;
using PrisonAdministrationFramework.Core.ViewModels;

namespace PrisonAdministrationFramework.Core.Models
{
    public class Inmate
    {
       
        public string Id { get; private set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

       
        public Cell Cell { get; set; }
        public int CellId { get; set; }
        public string Offense { get; set; }
       
        public string Sentence { get; set; }
        
        public string Remission { get; set; }

        public DateTime DateOfIncarceration { get; set; }
      
        public string DateOfRelease { get; private set; }
       

        public string FrontProfile { get; set; }
        public string SideProfile { get; set; }
        public bool HasLeft { get; private set; }
        public DateTime DateOfCreation { get; private set; }
        public string Complexion { get; set; }
        public long BankVerificationNumber { get; set; }
        public long IdentificationNumber { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string BirthCity { get; set; }
        public string Nationality { get; set; }
        public Inmate()
        {
            this.Id = Guid.NewGuid().ToString();
            this.DateOfCreation = DateTime.Now;
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
            Height = model.Height;
            Weight = model.Weight;
            Complexion = model.Complexion;
            BirthCity = model.BirthCity;
            Nationality = model.Nationality;
            IdentificationNumber = model.IdentificationNumber;
            BankVerificationNumber = model.BankVerificationNumber;
        }

        public void SaveFrontProfile(HttpPostedFileBase fileBase)
        {
            this.FrontProfile = string.Format(this.Id + Path.GetFileName(fileBase.FileName));
            fileBase.SaveAs( HttpContext.Current.Server.MapPath("//Content//Inmate//FrontProfile// ") + this.FrontProfile);
        }
        
        public void SaveSideProfile(HttpPostedFileBase fileBase)
        {
            this.SideProfile = string.Format(this.Id + Path.GetFileName(fileBase.FileName));
            fileBase.SaveAs( HttpContext.Current.Server.MapPath("//Content//Inmate//SideProfile// ") + this.SideProfile);
        }
    }
}