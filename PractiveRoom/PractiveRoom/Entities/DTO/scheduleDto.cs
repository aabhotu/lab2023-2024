using PractiveRoom.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiveRoom.Entities.DTO
{
    public class scheduleDto
    {
        public int scheduleId { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }

        public IEnumerable<roomDto> room { get; set; }

        public IEnumerable<teacherDto> teacher { get; set; }

        public IEnumerable<subjectDto> subject { get; set; }
    }
}
