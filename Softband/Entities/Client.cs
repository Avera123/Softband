using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public int IdBand { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public double Credit { get; set; }
    }
}
