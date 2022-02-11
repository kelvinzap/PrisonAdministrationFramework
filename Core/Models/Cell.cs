using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrisonAdministrationFramework.Core.Models
{
    public class Cell
    {
        public int Id { get; set; }
        public int OccupantNumber { get; set; }
        public ICollection<Inmate> Occupants { get; set; }

        public Cell()
        {
            Occupants = new Collection<Inmate>();
        }
    }
}