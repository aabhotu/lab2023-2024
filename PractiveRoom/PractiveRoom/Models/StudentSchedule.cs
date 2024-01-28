using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiveRoom.Models
{
    [Table("StudentSchedule")]
    public class StudentSchedule
    {
        [Required]
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(User))]
        public Guid userId { get; set; }
        [ForeignKey(nameof(Schedule))]
        public int calenderId { get; set;}
    }
}
