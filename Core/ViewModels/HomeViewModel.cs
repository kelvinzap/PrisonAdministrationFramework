using PrisonAdministrationSystem.Core.Models;

namespace PrisonAdministrationSystem.Core.ViewModels
{
    public class HomeViewModel
    {
        public int InmatesCount { get; set; }
        public int NewInmateCount { get; set; }
        public int StaffsCount { get; set; }
        public int NewStaffCount { get; set; }
        public int CellsCount { get; set; }
        public int ExConvicts { get; set; }
        public ApplicationUser User { get; set; }
    }
}