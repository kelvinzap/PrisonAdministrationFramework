using PrisonAdministrationSystem.Core;
using PrisonAdministrationSystem.Core.Repository;
using PrisonAdministrationSystem.Persistence.Repository;

namespace PrisonAdministrationSystem.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IApplicationUserRepository users { get; set; }
        public IInmateRepository inmates { get; set; }
        public IStaffRepository staffs { get; set; }
        public ICellRepository cells { get; set; }
        public IStaffRoleRepository staffRoles { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            users = new ApplicationUserRepository(context);
            inmates = new InmateRepository(context);
            staffs = new StaffRepository(context);
            cells = new CellRepository(context);
            staffRoles = new StaffRoleRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}