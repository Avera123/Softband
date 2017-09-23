using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Identification { get; set; }
        public DateTime Fecha { get; set; }
        public Double Amount { get; set; }
        public int IdAccountIn { get; set; }
        public bool Active { get; set; }
    }
}
