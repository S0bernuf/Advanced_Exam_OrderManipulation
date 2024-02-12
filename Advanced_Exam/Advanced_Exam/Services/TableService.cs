using Advanced_Exam.Models;
using Advanced_Exam.Respositories.Interfaces;
using Advanced_Exam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Services
{
    internal class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public IEnumerable<Table> GetAllTables()
        {
            return _tableRepository.GetAllTables();
        }

        public bool TableOccupied(int tableNumber)
        {
            return _tableRepository.GetTable(tableNumber).Occupied;
        }

        public void UpdateTableState(int tableNumber, bool occupied)
        {
            _tableRepository.UpdateTableState(tableNumber, occupied);
        }
    }
}
