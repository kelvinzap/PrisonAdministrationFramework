using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrisonAdministrationSystem.Models
{
    public class StaffDetailsViewModel
    {
        public Staff Staff { get; set; }
        public ApplicationUser User { get; set; }
    }
}