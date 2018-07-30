using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.Entities
{
    public class Transfer
    {
        public int Id { get; set; }
        public int IdAccountIn { get; set; }
        public int IdAccountOut { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
