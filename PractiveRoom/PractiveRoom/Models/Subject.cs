using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiveRoom.Models
{
    [Table("subject")]
    public class Subject
    {
        [Required]
        [Key]
        public int subjectId { get; set; }
        [Required]
        [StringLength(60)]
        public string subjectName { get; set; }
        public ICollection<Schedule> calenders { get; set; }
    }
}
