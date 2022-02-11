using System.Collections.Generic;
using PrisonAdministrationFramework.Core.Models;

namespace PrisonAdministrationFramework.Core.ViewModels
{
    public class CellsViewModel
    {
        public IEnumerable<Cell> Cells { get; set; }
        public ApplicationUser User { get; set; }
    }
}