using System.Collections.Generic;
using PrisonAdministrationSystem.Core.Models;

namespace PrisonAdministrationSystem.Core.ViewModels
{
    public class CellsViewModel
    {
        public IEnumerable<Cell> Cells { get; set; }
        public ApplicationUser User { get; set; }
    }
}