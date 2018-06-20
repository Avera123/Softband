using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdBank { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public double Amount { get; set; }
    }
}
