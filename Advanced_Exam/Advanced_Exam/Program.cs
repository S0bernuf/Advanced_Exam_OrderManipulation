using Advanced_Exam.Models;
using Advanced_Exam.Repositories.Interfaces;
using Advanced_Exam.Repositories;
using Advanced_Exam.Respositories.Interfaces;
using Advanced_Exam.Services.Interfaces;
using Advanced_Exam.Services;

namespace Advanced_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ITableRepository tableRepository = new TableRepository();
            ITableService tableService = new TableService(tableRepository);
            IItemRepository itemRepository = new ItemRepository();
            IItemService itemService = new ItemService(itemRepository);
            IOrderRepository orderRepository = new OrderRepository();
            IOrderService orderService = new OrderService(orderRepository);

            ConsoleUI consoleUI = new ConsoleUI(tableService, itemService, orderService);

            consoleUI.Run();
        }

    }
}
