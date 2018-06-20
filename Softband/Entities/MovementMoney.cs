using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.Entities
{
    public class MovementMoney
    {
        public int Id { get; set; }
        public int IdAccount { get; set; }
        public int IdCatMovement { get; set; }
        public int IdTypeMovement { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }
}
