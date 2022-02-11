﻿using System.Collections.Generic;
using System.Linq;
using PrisonAdministrationSystem.Core.Models;
using PrisonAdministrationSystem.Core.Repository;

namespace PrisonAdministrationSystem.Persistence.Repository
{
    public class CellRepository : ICellRepository
    {
        private readonly ApplicationDbContext _context;

        public CellRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cell> GetAllCells()
        {
            return _context.Cells.ToList();
        }

        public Cell GetCell(int Id)
        {
            return _context.Cells.Single(p => p.Id == Id);
        }

        public void Add(Cell cell)
        {
            _context.Cells.Add(cell);
        }
    }
}