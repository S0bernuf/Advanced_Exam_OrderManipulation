using Advanced_Exam.Models;
using Advanced_Exam.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Repositories
{
    internal class TableRepository : ITableRepository
    {
        private const string TableFilePath = @"C:\Users\Jevgenij\source\repos\Advanced_Exam\Advanced_Exam\bin\Debug\net8.0\tables.txt";

        public IEnumerable<Table> GetAllTables()
        {
            List<Table> tables = new List<Table>();

            using (StreamReader reader = new StreamReader(TableFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Table table = ReadTableFromLine(line);
                    tables.Add(table);
                }
            }

            return tables;
        }

        public Table GetTable(int tableNumber)
        {
            foreach (var table in GetAllTables())
            {
                if (table.TableNumber == tableNumber)
                    return table;
            }

            return null;
        }

        public void UpdateTableState(int tableNumber, bool occupied)
        {
            List<Table> tables = new List<Table>();

            using (StreamReader reader = new StreamReader(TableFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Table table = ReadTableFromLine(line);
                    if (table.TableNumber == tableNumber)
                    {
                        table.Occupied = occupied;
                    }

                    tables.Add(table);
                }
            }

            using (StreamWriter writer = new StreamWriter(TableFilePath))
            {
                foreach (var table in tables)
                {
                    writer.WriteLine($"{table.TableNumber}: {table.NumberOfSeats}: {table.Occupied}");
                }
            }
        }
        private Table ReadTableFromLine(string line)
        {
            string[] parts = line.Split(':');
            int tableNumber = int.Parse(parts[0].Trim());
            int numberOfSeats = int.Parse(parts[1].Trim());
            bool occupied = bool.Parse(parts[2].Trim());
            return new Table { TableNumber = tableNumber, NumberOfSeats = numberOfSeats, Occupied = occupied };
        }
    }
}