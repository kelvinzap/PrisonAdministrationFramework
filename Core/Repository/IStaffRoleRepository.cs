using System.Collections.Generic;
using PrisonAdministrationFramework.Core.Models;

namespace PrisonAdministrationFramework.Core.Repository
{
    public interface IStaffRoleRepository
    {
        IEnumerable<StaffRole> GetAllStaffRoles();
    }
}