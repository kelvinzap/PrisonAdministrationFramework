using System.Collections.Generic;

namespace PrisonAdministrationSystem.Models
{
    public class CellsViewModel
    {
        public IEnumerable<Cell> Cells { get; set; }
        public ApplicationUser User { get; set; }
    }
}