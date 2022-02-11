using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PrisonAdministrationSystem.Core;
using PrisonAdministrationSystem.Core.Models;
using PrisonAdministrationSystem.Core.Repository;
using PrisonAdministrationSystem.Core.ViewModels;

namespace PrisonAdministrationSystem.Controllers
{
    public class InmateController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public InmateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
     
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new InmateFormViewModel
            {
                Cells = _unitOfWork.cells.GetAllCells()
            };
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.users.GetUser(userId);
            viewModel.User = user;
            return View("Create", viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InmateFormViewModel formViewModel)
        {
            if (!ModelState.IsValid)
            {
                formViewModel.Cells = _unitOfWork.cells.GetAllCells();
                var userId = User.Identity.GetUserId();
                var user = _unitOfWork.users.GetUser(userId);
                formViewModel.User = user;
                return View("Create", formViewModel);
            }
            var inmate = new Inmate
            {
                MiddleName = formViewModel.MiddleName,
                LastName = formViewModel.LastName,
                FirstName = formViewModel.FirstName,
                Gender = formViewModel.Gender,
                CellId = formViewModel.Cell,
                Sentence = formViewModel.Sentence,
                DateOfBirth = formViewModel.GetAge(),
                Offense = formViewModel.Offense,
                DateOfIncarceration = formViewModel.GetDateTime(),
                Height = formViewModel.Height,
                Weight = formViewModel.Weight,
                Nationality = formViewModel.Nationality,
                BirthCity = formViewModel.BirthCity,
                Complexion = formViewModel.Complexion,
                IdentificationNumber = formViewModel.IdentificationNumber,
                BankVerificationNumber = formViewModel.BankVerificationNumber
                
            };
            
            if (formViewModel.FrontProfile != null)
            {
                inmate.SaveFrontProfile(formViewModel.FrontProfile);
            }
               
            if (formViewModel.SideProfile != null)
            {
                inmate.SaveSideProfile(formViewModel.SideProfile);
            }

          
            inmate.GetDateOfRelease();
        
            
            _unitOfWork.inmates.Add(inmate);
            _unitOfWork.Complete();

                return RedirectToAction("Inmates", "Inmate");
          
        }

        [Authorize]
        public ActionResult Inmates(string query = null)
        {
            var inmates = _unitOfWork.inmates.GetAllInmates();
           
            if (!String.IsNullOrWhiteSpace(query))
            {
                inmates = inmates
                    .Where(p=>String
                        .Format((p.FirstName 
                                 + p.LastName 
                                 + p.MiddleName 
                                 +p.DateOfIncarceration.ToString("d MMM yyyy") 
                                 + p.DateOfRelease 
                                 + p.Offense 
                                 + p.CellId.ToString()).ToLower())
                        .Contains(String.Concat(query
                                .ToLower()
                                .Where(c => !Char.IsWhiteSpace(c)))) )
                    .ToList();
            }
            var viewModel = new InmatesViewModel
            {
                Inmates = inmates,
                SearchTerm = query
            };

          

          
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.users.GetUser(userId);
            viewModel.User = user; 
            _unitOfWork.Complete();
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(string Id)
        {
            var inmate = _unitOfWork.inmates.GetInmate(Id);

            if (inmate == null)
                return HttpNotFound();
            //Add more details fields
            var viewModel = new InmateFormViewModel
            {
                Id = inmate.Id,
                MiddleName = inmate.MiddleName,
                LastName = inmate.LastName,
                FirstName = inmate.FirstName,
                Gender = inmate.Gender,
                Cell = inmate.CellId,
                Sentence = inmate.Sentence,
                DateOfBirth = inmate.DateOfBirth.ToString("d MMM yyyy"),
                Offense = inmate.Offense,
                DateOfIncarceration = inmate.DateOfIncarceration.ToString("d MMM yyyy"),
                TimeOfIncarceration = inmate.DateOfIncarceration.ToString("HH:mm"),
                Cells = _unitOfWork.cells.GetAllCells(),
                Height = inmate.Height,
                Weight = inmate.Weight,
                Complexion = inmate.Complexion,
                BirthCity = inmate.BirthCity,
                Nationality = inmate.Nationality,
                IdentificationNumber = inmate.IdentificationNumber,
                BankVerificationNumber = inmate.BankVerificationNumber
            };
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.users.GetUser(userId);
            viewModel.User = user;
            return View("Create", viewModel);

        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Update(InmateFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Cells = _unitOfWork.cells.GetAllCells();
                var userId = User.Identity.GetUserId();
                var user = _unitOfWork.users.GetUser(userId);
                model.User = user;
                return View("Create", model);
            }

            var inmate = _unitOfWork.inmates.GetInmate(model.Id);

            if (inmate == null)
                return HttpNotFound();

            inmate.Modify(model);

            _unitOfWork.Complete();
            return RedirectToAction("Inmates", "Inmate");
        }

        [Authorize]
        public ActionResult Details(string Id, string query)
        {
            var inmate = _unitOfWork.inmates.GetInmate(Id);

            if (inmate == null)
                return HttpNotFound();

            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.users.GetUser(userId);
            var viewModel = new InmateDetailsViewModel
            {
                Inmate = inmate,
                User = user,
                Query = query
            };

            return View("InmateDetails", viewModel);
        }

        public ActionResult ExInmates()
        {
            var inmates = new InmatesViewModel
            {
                Inmates = _unitOfWork.inmates.GetAllExInmates()
            };
               
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.users.GetUser(userId);
            inmates.User = user;
            return View(inmates);
        }
    }
}