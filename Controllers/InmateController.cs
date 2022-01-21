using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View(viewModel);
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InmateFormViewModel formViewModel)
        {
            if (!ModelState.IsValid)
            {
                formViewModel.Cells = _context.Cells.ToList();

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
                Age = formViewModel.Age,
                Offense = formViewModel.Offense,
                DateOfIncarceration = formViewModel.GetDateTime(),
                
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
            _context.Inmates.Add(inmate);
            _context.SaveChanges();

                return RedirectToAction("Index", "Home");
          
        }

        public ActionResult Inmates()
        {
            var inmates = new InmatesViewModel
            {
                Inmates = _context.Inmates.ToList()
            };
            return View(inmates);
        }
    }
}