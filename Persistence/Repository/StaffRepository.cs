using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PrisonAdministrationSystem.Core.Models;
using PrisonAdministrationSystem.Core.Repository;

namespace PrisonAdministrationSystem.Persistence.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _context;

        public StaffRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Staff> GetAllStaffs()
        {
            return _context.Staffs.Where(p => !p.HasLeft).ToList();
        }

        public IEnumerable<Staff> GetNewStaffs(DateTime days30)
        {
            return _context.Staffs.Where(p => p.DateOfCreation >= days30 && !p.HasLeft).ToList();
        }


        public void Add(Staff staff)
        {
            _context.Staffs.Add(staff);
        }

        public IEnumerable<Staff> GetAllStaffsWithRoles()
        {
                 return  _context.Staffs
                        .Where(p => !p.HasLeft)
                        .Include(p => p.Role)
                        .ToList();
        }
        
        
        public Staff GetStaffWithRoles(string Id)
        {
            return _context.Staffs

                .Include(i => i.Role)
                .SingleOrDefault(p => p.Id == Id);
        }

        public Staff GetStaff(string Id)
        {
            return _context.Staffs
                .Single(p => p.Id == Id);
        }
    }
}