using EFCoreTestApp.Services;

namespace EFCoreTestApp
{
	public static class UserController
	{
		public static bool TryLogin(string login, string password) => AutorizationService.TryLogin(login, password);
	}
}
