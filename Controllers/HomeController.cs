using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PrisonAdministrationSystem.Models;

namespace PrisonAdministrationSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(p => p.Id == userId);
            var inmates = _context.Inmates.Where(p=>!p.HasLeft).ToList().Count();
            var staffs = _context.Staffs.Where(p=>!p.HasLeft).ToList().Count();
            var cells = _context.Cells.ToList().Count();
            var days30 = DateTime.Now.AddDays(-30);
            var newInmates = _context.Inmates.Where(p => p.DateOfCreation >= days30 && !p.HasLeft).ToList().Count();
            var newStaffs = _context.Staffs.Where(p => p.DateOfCreation >= days30 && !p.HasLeft).ToList().Count();
            var viewModel = new HomeViewModel
            {
                InmatesCount = inmates,
                NewInmateCount = newInmates,
                StaffsCount = staffs,
                NewStaffCount = newStaffs,
                CellsCount = cells,
                User = user
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}