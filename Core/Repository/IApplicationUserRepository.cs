using PrisonAdministrationSystem.Core.Models;

namespace PrisonAdministrationSystem.Core.Repository
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetUser(string userId);
    }
}