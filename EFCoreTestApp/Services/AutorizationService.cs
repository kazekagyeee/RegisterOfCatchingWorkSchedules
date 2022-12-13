using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTestApp.Services
{
	public static class AutorizationService
	{
		public static bool TryLogin(string login, string password)
		{
			var user = AppDBContext.Instance.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
			if (user == null) 
				return false;
			SessionService.SetUser(user);
			return true;
		}
	}
}
