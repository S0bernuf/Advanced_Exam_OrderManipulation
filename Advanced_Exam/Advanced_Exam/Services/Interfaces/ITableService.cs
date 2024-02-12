using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Exam.Models;

namespace Advanced_Exam.Services.Interfaces
{
    internal interface ITableService
    {
        bool TableOccupied(int tableNumber);
        IEnumerable<Table> GetAllTables();
        void UpdateTableState(int tableNumber, bool occupied);

    }
}
