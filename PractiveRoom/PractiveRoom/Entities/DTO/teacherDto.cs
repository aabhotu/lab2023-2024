using System.ComponentModel.DataAnnotations;

namespace PractiveRoom.Entities.DTO
{
    public class teacherDto
    {
        public Guid teacherId { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }
}
