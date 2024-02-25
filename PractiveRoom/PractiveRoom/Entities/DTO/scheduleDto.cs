using PractiveRoom.Models;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public int roomId { get; set; }
        //public roomDto room { get; set; }

        public Guid teacherId { get; set; }
        //public teacherDto teacher { get; set; }

        public int subjectId { get; set; }
        //public subjectDto subject { get; set; }
    }
}
