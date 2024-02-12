using Advanced_Exam.Models;
using Advanced_Exam.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Exam.Repositories.Interfaces;

namespace Advanced_Exam.Services
{
    internal class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<Item> GetAllItems(string filePath)
        {
            return _itemRepository.GetAllItems(filePath);
        }

        public Item GetItemByName(string itemName, string filePath)
        {
            return _itemRepository.GetItemByName(itemName, filePath);
        }
    }
}
