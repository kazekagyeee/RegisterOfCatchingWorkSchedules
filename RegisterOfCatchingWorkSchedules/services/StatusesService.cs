using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules.services
{
    public static class StatusesService
    {
        public static BindingList<Statuses> GetBindingList()
        {
            using (var dbContext = new RegisterDBContext())
            {
                dbContext.Statuses.Load();
                return dbContext.Statuses.Local.ToBindingList();
            }
            
        }
    }
}
