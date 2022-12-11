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
                var currendUser = new Users();
                var properties = typeof(Users).GetProperties();
                foreach (var property in properties)
                {
                    property.SetValue(currendUser, property.GetValue(user));
                }
                Program.Session.User = currendUser;
                return true;
            }
        }
    }
}
