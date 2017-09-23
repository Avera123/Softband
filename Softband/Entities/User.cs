using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
