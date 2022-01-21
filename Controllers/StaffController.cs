using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrisonAdministrationSystem.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult CreateStaff()
        {
            return View();
        }
    }
}