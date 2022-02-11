using System.Collections.Generic;
using PrisonAdministrationSystem.Core.Models;

namespace PrisonAdministrationSystem.Core.Repository
{
    public interface ICellRepository
    {
        IEnumerable<Cell> GetAllCells();
        Cell GetCell(int Id);
        void Add(Cell cell);
    }
}