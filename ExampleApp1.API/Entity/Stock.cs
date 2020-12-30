using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleApp1.API.Entity
{
    public class Stock
    {

        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int StockQuantity { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

    }
}
