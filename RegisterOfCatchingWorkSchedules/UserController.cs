namespace RegisterOfCatchingWorkSchedules
{
	public class UserController
	{
		public bool TryLogin(string login, string password) => AutorizationService.TryAutorizate(login, password);
	}
}
