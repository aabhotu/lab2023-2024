using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiveRoom.Models
{
    [Table("calender")]
    public class Calender
    {
        [Required]
        [Key]
        public int id { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }

        [ForeignKey(nameof(Room))]
        public int roomId { get; set; }
        public Room room { get; set; }

        [ForeignKey(nameof(Teacher))]
        public Guid teacherId { get; set; }
        public Teacher teacher { get; set; }

        [ForeignKey(nameof(Subject))]
        public int subjectId { get; set; }
        public Subject subject { get; set; }
        public ICollection<StudentCalender> studentCalenders { get; set; }
    }
}
