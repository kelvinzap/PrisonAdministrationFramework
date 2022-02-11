using System.Collections.Generic;
using PrisonAdministrationSystem.Core.Models;

namespace PrisonAdministrationSystem.Core.Repository
{
    public interface IStaffRoleRepository
    {
        IEnumerable<StaffRole> GetAllStaffRoles();
    }
}