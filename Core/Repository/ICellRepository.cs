using System.Collections.Generic;
using PrisonAdministrationFramework.Core.Models;

namespace PrisonAdministrationFramework.Core.Repository
{
    public interface ICellRepository
    {
        IEnumerable<Cell> GetAllCells();
        Cell GetCell(int Id);
        void Add(Cell cell);
    }
}