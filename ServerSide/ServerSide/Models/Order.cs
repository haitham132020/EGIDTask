using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSide.Models
{
    public class Order
    {
        public int StockID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PersonName { get; set; }
    }
}
