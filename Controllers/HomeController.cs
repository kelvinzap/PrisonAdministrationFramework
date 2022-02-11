using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PrisonAdministrationFramework.Core;
using PrisonAdministrationFramework.Core.ViewModels;
using PrisonAdministrationFramework.Core.Repository;

namespace PrisonAdministrationFramework.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index(string query = null)
        {
            var inmates = _unitOfWork.inmates.GetAllInmates();
            foreach (var inmate in inmates)
            {
                var dateRelease = DateTime.Parse(inmate.DateOfRelease);
                if (dateRelease <= DateTime.Now)
                {
                    inmate.Remove();
                }
            }
            _unitOfWork.Complete();
            var userId = User.Identity.GetUserId();
            var user = _unitOfWork.users.GetUser(userId);
            var inmateCount = _unitOfWork.inmates.GetAllInmates().ToList().Count();
            var staffs = _unitOfWork.staffs.GetAllStaffs().Count();
            var cells = _unitOfWork.cells.GetAllCells().ToList().Count();
            var days30 = DateTime.Now.AddDays(-30);
            var exConvicts = _unitOfWork.inmates.GetAllExInmates().ToList().Count;
            var newInmates = _unitOfWork.inmates.GetAllNewInmates(days30).ToList().Count();
            var newStaffs = _unitOfWork.staffs.GetNewStaffs(days30).Count();
            var viewModel = new HomeViewModel
            {
                InmatesCount = inmateCount,
                NewInmateCount = newInmates,
                StaffsCount = staffs,
                NewStaffCount = newStaffs,
                CellsCount = cells,
                User = user,
                ExConvicts = exConvicts
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