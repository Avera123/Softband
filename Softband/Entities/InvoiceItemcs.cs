using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.Entities
{
    public class InvoiceItemcs
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string CodeInvoice { get; set; }
        public string Note { get; set; }
    }
}
