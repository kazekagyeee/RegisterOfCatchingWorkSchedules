using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
    public class User
    {
        public string Login { get; set; }
        private string Password { get; set; }
        public Role Role { get; private set; }
        public Organisation Organisation { get; private set; }
        public Municipality Municipality { get; private set; }

        public bool SignIn(string login, string password)
        {
            //TODO
            return false;
        }
    }


}
