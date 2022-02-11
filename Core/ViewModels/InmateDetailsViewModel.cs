using PrisonAdministrationSystem.Core.Models;

namespace PrisonAdministrationSystem.Core.ViewModels
{
    public class InmateDetailsViewModel
    {
        public Inmate Inmate { get; set; }
        public ApplicationUser User { get; set; }
        public string Query { get; set; }
    }
}