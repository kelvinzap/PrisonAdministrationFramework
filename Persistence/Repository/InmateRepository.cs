using System;
using System.Collections.Generic;
using System.Linq;
using PrisonAdministrationFramework.Core.Models;
using PrisonAdministrationFramework.Core.Repository;

namespace PrisonAdministrationFramework.Persistence.Repository
{
    public class InmateRepository : IInmateRepository
    {
        private readonly ApplicationDbContext _context;

        public InmateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Inmate> GetAllInmates()
        {
            return  _context.Inmates
                .Where(p => !p.HasLeft)
                .ToList();
        }

        public IEnumerable<Inmate> GetAllExInmates()
        {
            return _context.Inmates
                .Where(p => p.HasLeft)
                .ToList();
        }

        public void Add(Inmate inmate)
        {
            _context.Inmates.Add(inmate);
        }

        public Inmate GetInmate(string Id)
        {
            return _context.Inmates.Single(p => p.Id == Id);
        }

        public IEnumerable<Inmate> GetAllNewInmates(DateTime days30)
        {
            return _context.Inmates
                .Where(p => p.DateOfCreation >= days30 && !p.HasLeft)
                .ToList();
        }

        public IEnumerable<Inmate> GetCellOccupants(int Id)
        {
            return _context.Inmates.Where(p => p.CellId == Id && !p.HasLeft).ToList();
        }
    }
}