using System.Collections.Generic;
using PrisonAdministrationSystem.Core.Models;

namespace PrisonAdministrationSystem.Core.ViewModels
{
    public class StaffsVewModel
    {
        public IEnumerable<Staff> Staffs { get; set; }
        public ApplicationUser User { get; set; }
        public string SearchTerm { get; set; }
    }
}