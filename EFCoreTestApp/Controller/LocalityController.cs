using EFCoreTestApp.Model;
using EFCoreTestApp.Services;
using Equin.ApplicationFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace EFCoreTestApp
{
	public static class LocalityController
	{
		public static LocalityArea GetAreaById(int areaId) => AppDBContext.Instance.Areas.Find(areaId);

		public static List<LocalityArea> GetAllAreas() => AppDBContext.Instance.Areas.ToList();

		public static BindingList<Locality> GetLocalitiesBindingList()
		{
			AppDBContext.Instance.Localities.Load();
			return AppDBContext.Instance.Localities.Local.ToBindingList();
		}

	}
}
