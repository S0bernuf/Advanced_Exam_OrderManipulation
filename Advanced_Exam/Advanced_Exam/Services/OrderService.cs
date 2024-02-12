using Advanced_Exam.Models;
using Advanced_Exam.Repositories.Interfaces;
using Advanced_Exam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Services
{
    internal class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddItemToOrder(Item item, Order order)
        {
            order.OrderedItems.Add(item);
        }

        public void FinishOrder(Order order)
        {
            _orderRepository.SaveOrder(order);
        }
    }
}
