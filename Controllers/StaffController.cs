using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
                Heading = "Add a new Staff",
                StatusOptions = status.ToList(),
                StaffRoles = _context.StaffRoles.ToList()
            };
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(p => p.Id == userId);
            viewModel.User = user;
            return View("CreateStaff", viewModel);
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
                var userId = User.Identity.GetUserId();
                var user = _context.Users.Single(p => p.Id == userId);
                model.User = user;
                return View("CreateStaff", model);
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
                PhoneNumber = model.PhoneNumber,
                Email = model.Email
                
            };
            staff.Passport = string.Format(staff.Id + Path.GetFileName(model.Passport.FileName));
            model.Passport.SaveAs(Server.MapPath("//Content//Staff// ") + staff.Passport);
          
            _context.Staffs.Add(staff);
            _context.SaveChanges();
            return RedirectToAction("Staffs", "Staff");
        }

        [Authorize]
        public ActionResult Staffs()
        {
            var staffs = new StaffsVewModel
            {
                Staffs = _context.Staffs
                    .Where(p => !p.HasLeft)
                    .Include(p=>p.Role)
                    .ToList()
            };
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(p => p.Id == userId);
            staffs.User = user;
            return View(staffs);
        }

        [Authorize]
        public ActionResult Edit(string Id)
        {
            var staff = _context.Staffs
                .Single(p => p.Id == Id);
            
            if (staff == null)
                return HttpNotFound();
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
                Id = staff.Id,
                Heading = "Edit Staff details",
                LastName = staff.LastName,
                FirstName = staff.FirstName,
                MiddleName = staff.MiddleName,
                MaidenName = staff.MaidenName,
                IdentificationNumber = staff.IdentificationNumber,
                BankVerificationNumber = staff.BankVerificationNumber,
                Gender = staff.Gender,
                DateOfBirth = staff.DateOfBirth.ToString("d MMM yyyy"),
                Nationality = staff.Nationality,
                Address = staff.Address,
                BirthCity = staff.BirthCity,
                MaritalStatus = staff.MaritalStatus,
                Height = staff.Height,
                Weight = staff.Weight,
                RoleId = staff.RoleId,
                PhoneNumber = staff.PhoneNumber,
                StatusOptions = status,
                StaffRoles = _context.StaffRoles.ToList(),
                Email = staff.Email
                
            };
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(p => p.Id == userId);
            viewModel.User = user;
            return View("CreateStaff", viewModel);

        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(StaffFormViewModel viewModel)
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
                viewModel.StatusOptions = status.ToList();
                viewModel.StaffRoles = _context.StaffRoles.ToList();
                var userId = User.Identity.GetUserId();
                var user = _context.Users.Single(p => p.Id == userId);
                viewModel.User = user;
                return View("CreateStaff", viewModel);
            }

            var staff = _context.Staffs
                .Single(p => p.Id == viewModel.Id);

            if (staff == null)
                return HttpNotFound();

            staff.Modify(viewModel);

            _context.SaveChanges();
            return RedirectToAction("Staffs", "Staff");
        }

        [Authorize]
        public ActionResult Details(string Id)
        {
            var staff = _context.Staffs.Where(i=>i.Id == Id).Include(i=>i.Role).SingleOrDefault();
            
            if (staff == null)
                return HttpNotFound();

            if (!User.Identity.IsAuthenticated)
                return new HttpUnauthorizedResult();

            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(p => p.Id == userId);
            var viewModel = new StaffDetailsViewModel
            {
                User = user,
                Staff = staff
            };

            return View("StaffDetails", viewModel);
        }

    }
}