using System.Linq;
using PrisonAdministrationFramework.Core.Models;
using PrisonAdministrationFramework.Core.Repository;

namespace PrisonAdministrationFramework.Persistence.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public ApplicationUser GetUser(string userId)
        {
            return _context.Users.Single(p => p.Id == userId);
        }
    }

}