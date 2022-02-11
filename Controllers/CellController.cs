using System;
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
    [Authorize]
    public class CellController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CellController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Create()
        {

            var cell = new Cell
            {
                OccupantNumber = 0
            };
            
            _unitOfWork.cells.Add(cell);
           _unitOfWork.Complete();

            return RedirectToAction("Cells", "Cell");
        }
        public ActionResult Cells()
        {
            var cells = _unitOfWork.cells.GetAllCells();
            foreach (var cell in cells)
            {
                cell.OccupantNumber = _unitOfWork.inmates.GetCellOccupants(cell.Id).Count();
            }
            _unitOfWork.Complete();
            var viewModel = new CellsViewModel
            {
                Cells = cells
            };
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.users.GetUser(userId);
            viewModel.User = user;
            return View("Cells",viewModel);
        }
    }
}