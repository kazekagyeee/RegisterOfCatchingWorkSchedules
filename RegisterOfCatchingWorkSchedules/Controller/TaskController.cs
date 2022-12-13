using RegisterOfCatchingWorkSchedules.Model;
using System.Collections.Specialized;

namespace RegisterOfCatchingWorkSchedules.Controller
{
    public static class TaskController
    {
        public static IReadOnlyList<int> GetDailyTasks(AreaCatchTask task)
        {
            var result = new List<int>();
            BitVector32 bitVector = new(task.DailyTasks);
            for (int i = 1; i <= 31; i++)
                if (bitVector[(int)Math.Pow(2,i)])
                    result.Add(i);
            return result;
        }
    }
}