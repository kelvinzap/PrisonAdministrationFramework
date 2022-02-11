using System;
using System.Collections.Generic;
using PrisonAdministrationFramework.Core.Models;

namespace PrisonAdministrationFramework.Core.Repository
{
    public interface IStaffRepository
    {
        IEnumerable<Staff> GetAllStaffs();
        IEnumerable<Staff> GetNewStaffs(DateTime days30);
        void Add(Staff staff);
        IEnumerable<Staff> GetAllStaffsWithRoles();
        Staff GetStaffWithRoles(string Id);
        Staff GetStaff(string Id);
    }
}