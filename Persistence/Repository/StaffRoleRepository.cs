using System.Collections.Generic;
using System.Linq;
using PrisonAdministrationFramework.Core.Models;
using PrisonAdministrationFramework.Core.Repository;

namespace PrisonAdministrationFramework.Persistence.Repository
{
    public class StaffRoleRepository : IStaffRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public StaffRoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<StaffRole> GetAllStaffRoles()
        {
            return _context.StaffRoles.ToList();
        }
    }
}