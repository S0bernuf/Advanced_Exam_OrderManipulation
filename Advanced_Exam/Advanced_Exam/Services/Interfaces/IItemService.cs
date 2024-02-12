using Advanced_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Services.Interfaces
{
    internal interface IItemService
    {
        IEnumerable<Item> GetAllItems(string filePath);
        Item GetItemByName(string itemName, string filePath);
    }
}
