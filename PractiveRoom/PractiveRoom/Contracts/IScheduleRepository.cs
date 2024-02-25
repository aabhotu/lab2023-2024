using PractiveRoom.Models;

namespace PractiveRoom.Contracts
{
    public interface IScheduleRepository
    {
        IEnumerable<Schedule> GetAllSchedule();
        Schedule GetScheduleById(int id);
        //Schedule GetScheduleDetals(Schedule schedule);
        void CreateSchedule(Schedule schedule);
        void UpdateSchedule(Schedule schedule);
        void DeleteSchedule(Schedule schedule);
    }
}
