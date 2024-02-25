using PractiveRoom.Models;

namespace PractiveRoom.Entities.DTO
{
    public class ScheduleForChange
    {
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public int roomId { get; set; }

        public Guid teacherId { get; set; }

        public int subjectId { get; set; }
    }
}
