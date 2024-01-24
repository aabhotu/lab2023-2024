using RestApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PractiveRoom.Models
{
    [Table("studentCalender")]
    public class StudentCalender
    {
        [Required]
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(User))]
        public Guid userId { get; set; }
        [ForeignKey(nameof(Calender))]
        public int calenderId { get; set;}
    }
}
