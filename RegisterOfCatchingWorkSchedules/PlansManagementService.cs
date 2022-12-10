using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
    public class PlansManagementService
    {
        public List<Plans> GetAllowedPlans()
        {
            var currentUser = Program.Session.User;
            var userRoles = currentUser.Roles;
            /*if (currentUser != null)
            {
                var powers = Program.DBContext.RolePowers
                    .Select(x => x.RoleID == currentUser.ID).ToList();
            }*/

            throw new NotImplementedException();
        }
    }
}
