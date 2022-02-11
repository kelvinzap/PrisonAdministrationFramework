using PrisonAdministrationFramework.Core.Models;

namespace PrisonAdministrationFramework.Core.Repository
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetUser(string userId);
    }
}