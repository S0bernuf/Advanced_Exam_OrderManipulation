using Advanced_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Services.Interfaces
{
    internal interface IOrderService
    {
        void AddItemToOrder(Item item, Order order);
        void FinishOrder(Order order);
    }
}
