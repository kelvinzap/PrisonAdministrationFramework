using System.ComponentModel.DataAnnotations;

namespace PrisonAdministrationFramework.Core.Models
{
    public class StaffRole
    {
        public byte Id { get; private set; }
        [Required]
        public string Name { get; private set; }
    }
}