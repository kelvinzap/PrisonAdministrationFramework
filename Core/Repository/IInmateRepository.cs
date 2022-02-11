using System;
using System.Collections.Generic;
using PrisonAdministrationFramework.Core.Models;

namespace PrisonAdministrationFramework.Core.Repository
{
    public interface IInmateRepository
    {
        IEnumerable<Inmate> GetAllInmates();
        IEnumerable<Inmate> GetAllExInmates();
        void Add(Inmate inmate);
        Inmate GetInmate(string Id);
        IEnumerable<Inmate> GetAllNewInmates(DateTime days30);
        IEnumerable<Inmate> GetCellOccupants(int Id);
    }
}