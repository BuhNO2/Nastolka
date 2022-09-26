using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastol
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public string Enterprice { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronomic { get; set; }

        public DateTime DateofBirth { get; set; }
    }
}
