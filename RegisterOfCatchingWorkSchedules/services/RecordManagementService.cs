using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
    public static class RecordManagementService
    {
        public static List<Records> GetRecords(int planID)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                return dbContext.Records.Where(x => x.RecordPlanID == planID).ToList();
            }
        }

        public static void CreateRecord(int placeID, int planID, DateTime date)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                var record = new Records();
                record.PlaceID = placeID;
                record.RecordPlanID = planID;
                record.RecordDate = date;
                dbContext.Records.Add(record);
                dbContext.SaveChanges();
            }
        }

        public static void DeleteRecord(int recordID)
        {
            using (var dbContext = new RegisterOfCathingWorkSchedulesEntities())
            {
                var recordToDelete = dbContext.Records.FirstOrDefault(x => x.ID == recordID);
                dbContext.Records.Remove(recordToDelete);
                dbContext.SaveChanges();
            }
        }
    }
}
