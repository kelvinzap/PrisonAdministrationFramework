using System.Collections.Generic;
using PrisonAdministrationFramework.Core.Models;

namespace PrisonAdministrationFramework.Core.ViewModels
{
    public class StaffsVewModel
    {
        public IEnumerable<Staff> Staffs { get; set; }
        public ApplicationUser User { get; set; }
        public string SearchTerm { get; set; }
    }
}