using PrisonAdministrationFramework.Core.Repository;

namespace PrisonAdministrationFramework.Core
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository users { get; set; }
        IInmateRepository inmates { get; set; }
        IStaffRepository staffs { get; set; }
        ICellRepository cells { get; set; }
        IStaffRoleRepository staffRoles { get; set; }
        void Complete();
    }
}