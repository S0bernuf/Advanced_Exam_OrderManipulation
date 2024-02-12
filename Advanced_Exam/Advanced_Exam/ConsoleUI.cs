using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Exam.Models;
using Advanced_Exam.Services.Interfaces;

namespace Advanced_Exam
{
    internal class ConsoleUI
    {
        private readonly ITableService _tableService;
        private readonly IItemService _itemService;
        private readonly IOrderService _orderService;
        private Order _currentOrder;
        private const string _foodFilePath = "food.txt";
        private const string _drinkFilePath = "drinks.txt";

        public ConsoleUI(ITableService tableService, IItemService itemService, IOrderService orderService)
        {
            _tableService = tableService;
            _itemService = itemService;
            _orderService = orderService;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Start Order");
                Console.WriteLine("2. Add Food");
                Console.WriteLine("3. Add Drink");
                Console.WriteLine("4. Finish Order");
                Console.WriteLine("5. Exit");
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StartOrder();
                        break;
                    case "2":
                        if (_currentOrder != null)
                            AddFood();
                        else
                            Console.WriteLine("Please start an order first.");
                        break;
                    case "3":
                        if (_currentOrder != null)
                            AddDrink();
                        else
                            Console.WriteLine("Please start an order first.");
                        break;
                    case "4":
                        if (_currentOrder != null)
                            FinishOrder();
                        else
                            Console.WriteLine("No order in progress.");
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private void StartOrder()
        {
            Console.WriteLine("Available Tables:");
            var tables = _tableService.GetAllTables();
            foreach (var table in tables)
            {
                Console.WriteLine($"Table Number: {table.TableNumber}, Seats: {table.NumberOfSeats}, Occupied: {(table.Occupied ? "Yes" : "No")}");
            }

            Console.Write("Select the table number to start the order: ");
            if (int.TryParse(Console.ReadLine(), out int tableNumber))
            {
                if (_tableService.TableOccupied(tableNumber))
                {
                    Console.WriteLine("Table is already occupied. Select another one.");
                }
                else
                {
                    _currentOrder = new Order();
                    _currentOrder.TableNumber = tableNumber;
                    _tableService.UpdateTableState(tableNumber, true);
                    Console.WriteLine($"Order started for Table {tableNumber}");
                }
            }
        }

        private void AddFood()
        {
            Console.WriteLine("Food Menu:");
            DisplayMenu(_foodFilePath);

            Console.Write("Enter the name of the food item to add: ");
            string foodName = Console.ReadLine();
            var foodItem = _itemService.GetItemByName(foodName, _foodFilePath);

            if (foodItem != null)
            {
                _orderService.AddItemToOrder(foodItem, _currentOrder);
                Console.WriteLine($"Added {foodItem.Name} to the order");
            }
            else
            {
                Console.WriteLine($"{foodName} not on the menu");
            }
        }

        private void AddDrink()
        {
            Console.WriteLine("Drink Menu:");
            DisplayMenu(_drinkFilePath);

            Console.Write("Enter the name of the drink item to add: ");
            string drinkName = Console.ReadLine();
            var drinkItem = _itemService.GetItemByName(drinkName, _drinkFilePath);

            if (drinkItem != null)
            {
                _orderService.AddItemToOrder(drinkItem, _currentOrder);
                Console.WriteLine($"Added {drinkItem.Name} to the order");
            }
            else
            {
                Console.WriteLine($"{drinkName} not on the menu");
            }
        }

        private void FinishOrder()
        {
            Console.WriteLine($"Order Receipt for Table {_currentOrder.TableNumber}:");
            decimal total = 0;
            foreach (var item in _currentOrder.OrderedItems)
            {
                Console.WriteLine($"{item.Name} - ${item.Price}$");
                total += item.Price;
            }
            Console.WriteLine($"Total: ${total}$");


            _orderService.FinishOrder(_currentOrder);


            _tableService.UpdateTableState(_currentOrder.TableNumber, false);
            Console.WriteLine($"Table {_currentOrder.TableNumber} is now vacant.");

            _currentOrder = null;
        }

        private void DisplayMenu(string filePath)
        {
            var items = _itemService.GetAllItems(filePath);
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Name} - ${item.Price}$");
            }
        }
    }
}


