using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.Entities
{
    public class Debt
    {
        public int Id { get; set; }
        public string IDClient { get; set; }
        public int IDBanda { get; set; }
        public string NameClient { get; set; }
        public string CodFact { get; set; }
        public double Amount { get; set; }
        public string Date { get; set; }
        public bool Active { get; set; }
    }
}
