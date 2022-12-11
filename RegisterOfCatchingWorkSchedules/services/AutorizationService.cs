using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
    public static class AutorizationService
    {
        public static bool TryAutorizate(string login, string password)
        {
            using (var dbContext = new RegisterDBContext())
            {
                var user = dbContext.Users
                .FirstOrDefault(x => x.UserLogin == login && x.UserPassword == password);
                if (user == null) return false;
                Program.Session.User = user;
                return true;
            }
        }
    }
}
