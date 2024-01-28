using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiveRoom.Models
{
    [Table("room")]
    public class Room
    {
        [Required]
        [Key]
        public int roomId { get; set; }
        [Required]
        [StringLength(50)]
        public string roomName { get; set; }
        public ICollection<Schedule> calenders { get; set; }
    }
}
