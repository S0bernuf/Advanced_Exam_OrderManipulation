using Advanced_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Repositories.Interfaces
{
    internal interface IOrderRepository
    {
        void SaveOrder(Order order);
    }
}
