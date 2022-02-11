using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;
using Grpc.Core;
using PrisonAdministrationFramework.Core.ViewModels;

namespace PrisonAdministrationFramework.Core.Models
{
    public class Staff
    {
        public string Id { get; private set; }
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
        public string  Email { get; set; }
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

        public bool HasLeft { get; private set; }
        public Staff()
        {
            Id = Guid.NewGuid().ToString();
            DateOfCreation = DateTime.Now;
        }

        public void Remove()
        {
            HasLeft = true;
        }

        public void Modify(StaffFormViewModel model)
        {
            LastName = model.LastName;
            FirstName = model.FirstName;
            MiddleName = model.MiddleName;
            MaidenName = model.MaidenName;
            IdentificationNumber = model.IdentificationNumber;
            BankVerificationNumber = model.BankVerificationNumber;
            Gender = model.Gender;
            DateOfBirth = model.GetDateOfBirth();
            Nationality = model.Nationality;
            Address = model.Address;
            BirthCity = model.BirthCity;
            MaritalStatus = model.MaritalStatus;
            Height = model.Height;
            Weight = model.Weight;
            RoleId = model.RoleId;
            PhoneNumber = model.PhoneNumber;
            Email = model.Email;

        }

        public void SavePassport(HttpPostedFileBase modelPassport)
        {
            this.Passport = string.Format(this.Id + Path.GetFileName(modelPassport.FileName));
            modelPassport.SaveAs(HttpContext.Current.Server.MapPath("//Content//Staff// ") + this.Passport);
        }
    }
}