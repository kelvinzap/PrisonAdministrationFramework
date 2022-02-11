using System.ComponentModel.DataAnnotations;

namespace PrisonAdministrationSystem.Core.Models
{
    public class StaffRole
    {
        public byte Id { get; private set; }
        [Required]
        public string Name { get; private set; }
    }
}