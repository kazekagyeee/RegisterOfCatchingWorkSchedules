﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
    public static class AutorisationService
    {
        public static bool Autorise(string login, string password)
        {
            var user = Program.DBContext.Users
                .FirstOrDefault(x => x.UserLogin == login && x.UserPassword == password);
            if (user == null) return false;
            Program.Session.User = user;
            return true;
        }
    }
}
