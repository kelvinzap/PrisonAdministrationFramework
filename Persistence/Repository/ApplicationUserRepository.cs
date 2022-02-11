using System.Linq;
using PrisonAdministrationSystem.Core.Models;
using PrisonAdministrationSystem.Core.Repository;

namespace PrisonAdministrationSystem.Persistence.Repository
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