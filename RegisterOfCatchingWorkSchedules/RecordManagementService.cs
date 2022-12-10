using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterOfCatchingWorkSchedules
{
    public class RecordManagementService
    {
        public List<Records> GetRecords(int planID)
        {
            return Program.DBContext.Records.Where(x => x.RecordPlanID == planID).ToList();
        }

        public void CreateRecord(int placeID, int planID, DateTime date)
        {
            var record = new Records();
            record.PlaceID = placeID;
            record.RecordPlanID = planID;
            record.RecordDate = date;
            Program.DBContext.Records.Add(record);
        }

        public void DeleteRecord(int recordID)
        {
            var recordToDelete = Program.DBContext.Records.FirstOrDefault(x => x.ID == recordID);
            Program.DBContext.Records.Remove(recordToDelete);
        }
    }
}
