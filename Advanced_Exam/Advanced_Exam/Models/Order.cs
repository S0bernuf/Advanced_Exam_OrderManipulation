using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Advanced_Exam.Models
{
    internal class Order
    {
        public List<Item> OrderedItems { get; set; } = new List<Item>();
        public int TableNumber { get; set; }
        public DateTime OrderDateTime { get; set; } = DateTime.Now;
    }
}
