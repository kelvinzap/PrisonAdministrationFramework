using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrisonAdministrationSystem.Models
{
    public class StaffsVewModel
    {
        public IEnumerable<Staff> Staffs { get; set; }
        public ApplicationUser User { get; set; }
        public string SearchTerm { get; set; }
    }
}