using System.Collections.Generic;
using System.Linq;
using PrisonAdministrationSystem.Core.Models;
using PrisonAdministrationSystem.Core.Repository;

namespace PrisonAdministrationSystem.Persistence.Repository
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