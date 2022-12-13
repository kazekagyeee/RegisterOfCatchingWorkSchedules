using EFCoreTestApp.Model;

namespace EFCoreTestApp.Services
{
	public static class SessionService
	{
		public static User CurrentUser { get; private set; }

		public static event Action<User> OnUserChanged;

		public static void SetUser(User user)
		{
			CurrentUser = user;
			OnUserChanged?.Invoke(user);
		}
	}
}
