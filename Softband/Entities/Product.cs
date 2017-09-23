using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; } 
        public double CostBuy { get; set; }
        public double CostSale { get; set; }
        public int Stock { get; set; }
    }
}
