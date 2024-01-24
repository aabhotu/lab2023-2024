using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiveRoom.Models
{
    [Table("teacher")]
    public class Teacher
    {
        [Required]
        [Key]
        public Guid teacherId { get; set; }
        [Required]
        [StringLength(100)]
        public string name { get; set; }
        public ICollection<Calender> calenders { get; set; }
    }
}
