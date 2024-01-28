using PractiveRoom.Contracts;
using PractiveRoom.Entities;
using PractiveRoom.Models;

namespace PractiveRoom.Repository
{
    public class ScheduleRepository: RepositoryBase<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(RepositoryContext context): base(context) { }

        public void CreateSchedule(Schedule schedule) => Create(schedule);

        public void DeleteSchedule(Schedule schedule) => Delete(schedule);
        public void UpdateSchedule(Schedule schedule) => Update(schedule);

        public IEnumerable<Schedule> GetAllSchedule()
        {
            return All().OrderBy(i=> i.startTime).ToList();
        }

        public Schedule GetScheduleById(int id)
        {
            return Find(i => i.scheduleId == id).FirstOrDefault();
        }

    }
}
