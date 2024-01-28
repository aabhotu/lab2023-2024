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
        public roomDto room { get; set; }

        public teacherDto teacher { get; set; }

        public subjectDto subject { get; set; }
    }
}
