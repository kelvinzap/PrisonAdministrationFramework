using System.Collections.Generic;
using PrisonAdministrationFramework.Core.Models;

namespace PrisonAdministrationFramework.Core.ViewModels
{
    public class InmatesViewModel
    {
        public IEnumerable<Inmate> Inmates { get; set; }
        public ApplicationUser User { get; set; }
        public string SearchTerm { get; set; }
    }
}