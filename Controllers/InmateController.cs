﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PrisonAdministrationSystem.Models;

namespace PrisonAdministrationSystem.Controllers
{
    public class InmateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InmateController()
        {
            _context = new ApplicationDbContext();
        }
     
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new InmateFormViewModel
            {
                Cells = _context.Cells.ToList()
            };
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(p => p.Id == userId);
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
                formViewModel.Cells = _context.Cells.ToList();
                var userId = User.Identity.GetUserId();
                var user = _context.Users.Single(p => p.Id == userId);
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
                    inmate.FrontProfile = string.Format(inmate.Id+ Path.GetFileName(formViewModel.FrontProfile.FileName));
                    formViewModel.FrontProfile.SaveAs(Server.MapPath("//Content//Inmate//FrontProfile// ") + inmate.FrontProfile);
            }
               
            if (formViewModel.SideProfile != null)
            {
                    inmate.SideProfile = string.Format(inmate.Id+ Path.GetFileName(formViewModel.SideProfile.FileName));
                    formViewModel.SideProfile.SaveAs(Server.MapPath("//Content//Inmate//SideProfile// ") + inmate.SideProfile);
            }

          
            inmate.GetDateOfRelease();
            var cell = _context.Cells.Single(p => p.Id == inmate.CellId);
            cell.OccupantNumber += 1;
            _context.Inmates.Add(inmate);
            _context.SaveChanges();

                return RedirectToAction("Inmates", "Inmate");
          
        }

        [Authorize]
        public ActionResult Inmates(string query = null)
        {
            var inmatees = _context.Inmates.ToList();
           
            foreach (var inmate in inmatees)
            {
                var dateRelease = DateTime.Parse(inmate.DateOfRelease);
                if (dateRelease <= DateTime.Now)
                {
                    inmate.Remove();
                }
            }

            _context.SaveChanges();
            var inmates = _context.Inmates
                .Where(p => !p.HasLeft)
                .ToList();
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
            var user = _context.Users.Single(p => p.Id == userId);
            viewModel.User = user;
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Edit(string Id)
        {
            var inmate = _context.Inmates
                .Single(p => p.Id == Id);

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
                Cells = _context.Cells.ToList(),
                Height = inmate.Height,
                Weight = inmate.Weight,
                Complexion = inmate.Complexion,
                BirthCity = inmate.BirthCity,
                Nationality = inmate.Nationality,
                IdentificationNumber = inmate.IdentificationNumber,
                BankVerificationNumber = inmate.BankVerificationNumber
            };
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(p => p.Id == userId);
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
                model.Cells = _context.Cells.ToList();
                var userId = User.Identity.GetUserId();
                var user = _context.Users.Single(p => p.Id == userId);
                model.User = user;
                return View("Create", model);
            }

            var inmate= _context.Inmates
                .Single(p => p.Id == model.Id);

            if (inmate == null)
                return HttpNotFound();

            inmate.Modify(model);

            _context.SaveChanges();
            return RedirectToAction("Inmates", "Inmate");
        }

        [Authorize]
        public ActionResult Details(string Id, string query)
        {
            var inmate = _context.Inmates.Single(p => p.Id == Id);

            if (inmate == null)
                return HttpNotFound();

            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(p => p.Id == userId);
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
                Inmates = _context.Inmates
                    .Where(p => p.HasLeft)
                    .ToList()
            };
               
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(p => p.Id == userId);
            inmates.User = user;
            return View(inmates);
        }
    }
}