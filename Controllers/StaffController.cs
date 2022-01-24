using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrisonAdministrationSystem.Models;

namespace PrisonAdministrationSystem.Controllers
{
    public class StaffController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Staff
        [Authorize]
        public ActionResult CreateStaff()
        {

            var status = new List<MarritalStatus>()
            {
                new MarritalStatus{Id = 1, Name = "Single"},
                new MarritalStatus{Id = 2, Name = "Married"},
                new MarritalStatus{Id = 3, Name = "Divorced"},
                new MarritalStatus{Id = 4, Name = "Separated"},
                new MarritalStatus{Id = 5, Name = "Widow/Widower"}
            };

            var viewModel = new StaffFormViewModel
            {
                StatusOptions = status.ToList(),
                StaffRoles = _context.StaffRoles.ToList()
            };

            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStaff(StaffFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var status = new List<MarritalStatus>()
                {
                    new MarritalStatus{Id = 1, Name = "Single"},
                    new MarritalStatus{Id = 2, Name = "Married"},
                    new MarritalStatus{Id = 3, Name = "Divorced"},
                    new MarritalStatus{Id = 4, Name = "Separated"},
                    new MarritalStatus{Id = 5, Name = "Widow/Widower"}
                };
                model.StatusOptions = status.ToList();
                model.StaffRoles = _context.StaffRoles.ToList();
                return View(model);
            }
            var staff = new Staff
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                MaidenName = model.MaidenName,
                IdentificationNumber = model.IdentificationNumber,
                BankVerificationNumber = model.BankVerificationNumber,
                Gender = model.Gender,
                DateOfBirth = model.GetDateOfBirth(),
                Nationality = model.Nationality,
                Address = model.Address,
                BirthCity = model.BirthCity,
                MaritalStatus = model.MaritalStatus,
                Height = model.Height,
                Weight = model.Weight,
                RoleId = model.RoleId,
                PhoneNumber = model.PhoneNumber
            };
            staff.Passport = string.Format(staff.Id + Path.GetFileName(model.Passport.FileName));
            model.Passport.SaveAs(Server.MapPath("//Content//Staff// ") + staff.Passport);
          
            _context.Staffs.Add(staff);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Staffs()
        {
            var staffs = new StaffsVewModel
            {
                Staffs = _context.Staffs
                    .Include(p=>p.Role)
                    .ToList()
            };
            return View(staffs);
        }



    }
}