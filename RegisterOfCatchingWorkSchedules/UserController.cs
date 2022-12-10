using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegisterOfCatchingWorkSchedules;
using System.Data.Entity;

namespace RegisterOfCatchingWorkSchedules
{
	public class UserController
	{
		public bool TryLogin(string login, string password) => AutorizationService.TryAutorizate(login, password);			
	}
}
