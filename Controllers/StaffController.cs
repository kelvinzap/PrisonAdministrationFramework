using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PrisonAdministrationFramework.Core;
using PrisonAdministrationFramework.Core.Models;
using PrisonAdministrationFramework.Core.ViewModels;
using PrisonAdministrationFramework.Core.Repository;

namespace PrisonAdministrationFramework.Controllers
{
    public class StaffController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                StaffRoles = _unitOfWork.staffRoles.GetAllStaffRoles()
            };
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.users.GetUser(userId);
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
                model.StaffRoles = _unitOfWork.staffRoles.GetAllStaffRoles();
                var userId = User.Identity.GetUserId();
                var user = _unitOfWork.users.GetUser(userId);
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
            staff.SavePassport(model.Passport);
           

            _unitOfWork.staffs.Add(staff);
            _unitOfWork.Complete();
          
            return RedirectToAction("Staffs", "Staff");
        }

        [Authorize]
        public ActionResult Staffs(string query = null)
        {
            var staffs = _unitOfWork.staffs.GetAllStaffsWithRoles();
            if (!String.IsNullOrWhiteSpace(query))
            {
                staffs = staffs
                    .Where(p => String
                        .Format((p.FirstName
                                 + p.LastName
                                 + p.MiddleName
                                 + p.DateOfCreation
                                 + p.Role
                                 + p.PhoneNumber).ToLower())
                        .Contains(String.Concat(query
                            .ToLower()
                            .Where(c => !Char.IsWhiteSpace(c)))))
                    .ToList();
            }
            var viewModel = new StaffsVewModel
            {
                Staffs = staffs,
                SearchTerm = query
            };
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.users.GetUser(userId);
            viewModel.User = user;
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(string Id)
        {
            var staff = _unitOfWork.staffs.GetStaff(Id);
            
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
                StaffRoles = _unitOfWork.staffRoles.GetAllStaffRoles(),
                Email = staff.Email
                
            };
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.users.GetUser(userId);
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
                viewModel.StaffRoles = _unitOfWork.staffRoles.GetAllStaffRoles();
                var userId = User.Identity.GetUserId();
                var user = _unitOfWork.users.GetUser(userId);
                viewModel.User = user;
                return View("CreateStaff", viewModel);
            }

            var staff = _unitOfWork.staffs.GetStaff(viewModel.Id);

            if (staff == null)
                return HttpNotFound();

            staff.Modify(viewModel);

            _unitOfWork.Complete();
            return RedirectToAction("Staffs", "Staff");
        }

        [Authorize]
        public ActionResult Details(string Id)
        {
            var staff = _unitOfWork.staffs.GetStaffWithRoles(Id);
            
            if (staff == null)
                return HttpNotFound();

            if (!User.Identity.IsAuthenticated)
                return new HttpUnauthorizedResult();

            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.users.GetUser(userId);
            var viewModel = new StaffDetailsViewModel
            {
                User = user,
                Staff = staff
            };

            return View("StaffDetails", viewModel);
        }

    }
}