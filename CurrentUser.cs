using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nastol
{
    internal class CurrentUser
    {
        private static User _user = new User();
        public static User user
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}
