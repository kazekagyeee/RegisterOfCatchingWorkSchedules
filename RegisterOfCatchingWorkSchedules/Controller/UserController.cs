﻿using RegisterOfCatchingWorkSchedules.Services;

namespace RegisterOfCatchingWorkSchedules
{
	public static class UserController
	{
		public static bool TryLogin(string login, string password) => AutorizationService.TryLogin(login, password);
	}
}