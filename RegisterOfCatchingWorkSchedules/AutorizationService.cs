using System.Linq;

namespace RegisterOfCatchingWorkSchedules
{
	public static class AutorizationService
	{
		public static bool TryAutorizate(string login, string password)
		{
			var user = Program.DBContext.Users
				.FirstOrDefault(x => x.UserLogin == login && x.UserPassword == password);
			if (user == null) return false;
			Program.Session.User = user;
			return true;
		}
	}
}
