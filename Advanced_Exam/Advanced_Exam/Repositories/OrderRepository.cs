using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Exam.Models;
using Advanced_Exam.Repositories.Interfaces;

namespace Advanced_Exam.Repositories
{
    internal class OrderRepository : IOrderRepository
    {
        private const string _ordersFilePath = @"C:\Users\Jevgenij\source\repos\Advanced_Exam\Advanced_Exam\bin\Debug\net8.0\orders.txt";

        public void SaveOrder(Order order)
        {
            string orderString = Order(order);
            File.AppendAllText(_ordersFilePath, orderString + Environment.NewLine);
        }

        private string Order(Order order)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Order for Table {order.TableNumber}");
            foreach (var item in order.OrderedItems)
            {
                sb.AppendLine($"{item.Name} - ${item.Price}$");
            }
            sb.AppendLine($"Total: ${order.OrderedItems.Sum(i => i.Price)}$");
            return sb.ToString();
        }
    }
}
