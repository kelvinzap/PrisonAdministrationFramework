using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PrisonAdministrationSystem.Models;

namespace PrisonAdministrationSystem.Controllers
{
    [Authorize]
    public class CellController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CellController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {

            var cell = new Cell
            {
                OccupantNumber = 0
            };
            _context.Cells.Add(cell);
            _context.SaveChanges();

            return RedirectToAction("Cells", "Cell");
        }
        public ActionResult Cells()
        {
            var cells = _context.Cells.ToList();
            var viewModel = new CellsViewModel
            {
                Cells = cells
            };
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(p => p.Id == userId);
            viewModel.User = user;
            return View("Cells",viewModel);
        }
    }
}