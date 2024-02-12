using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Exam.Models;
using Advanced_Exam.Repositories.Interfaces;

namespace Advanced_Exam.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        public IEnumerable<Item> GetAllItems(string filePath)
        {
            var items = new List<Item>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3)
                        {
                            string name = parts[0];
                            string type = parts[1];
                            if (decimal.TryParse(parts[2], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal price))
                            {
                                items.Add(new Item { Name = name, Type = type, Price = price });
                            }
                            else
                            {
                                Console.WriteLine($"Invalid price format in file for item: {name}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid line format in file: {line}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return items;
        }

        public Item GetItemByName(string itemName, string filePath)
        {
            return GetAllItems(filePath).FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
