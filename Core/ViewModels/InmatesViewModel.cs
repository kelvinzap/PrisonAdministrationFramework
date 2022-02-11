using System.Collections.Generic;
using PrisonAdministrationSystem.Core.Models;

namespace PrisonAdministrationSystem.Core.ViewModels
{
    public class InmatesViewModel
    {
        public IEnumerable<Inmate> Inmates { get; set; }
        public ApplicationUser User { get; set; }
        public string SearchTerm { get; set; }
    }
}