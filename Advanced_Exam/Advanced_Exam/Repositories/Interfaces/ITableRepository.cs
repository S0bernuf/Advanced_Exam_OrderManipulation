using Advanced_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Respositories.Interfaces
{
    internal interface ITableRepository
    {
        IEnumerable<Table> GetAllTables();
        Table GetTable(int tableNumber);
        void UpdateTableState(int tableNumber, bool occupied);
    }
}
