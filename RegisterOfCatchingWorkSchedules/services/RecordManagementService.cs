using System;
using System.Linq;

namespace RegisterOfCatchingWorkSchedules.Services
{
	public static class RecordManagementService
	{
		public static void CreateRecord(int planID, int placeID, int day)
		{
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
			{
				var record = new Records();
				var planDate = PlansManagementService.GetById(planID).PlanDate.Value;
				record.PlaceID = placeID;
				record.RecordPlanID = planID;
				record.RecordDate = new DateTime(planDate.Year, planDate.Month, day);
				dbContext.Records.Add(record);
				dbContext.SaveChanges();
			}
		}

		public static void RemoveRecord(int planID, int placeID, int day)
		{
			using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
			{
				var plan = dbContext.Plans.FirstOrDefault(x => x.ID == planID);
				var planDate = plan.PlanDate.Value;
				var recordDate = new DateTime(planDate.Year, planDate.Month, day);
				var record = plan.Records.FirstOrDefault(x => x.RecordDate == recordDate);
				dbContext.Records.Remove(record);
				dbContext.SaveChanges();
			}
		}
	}
}
