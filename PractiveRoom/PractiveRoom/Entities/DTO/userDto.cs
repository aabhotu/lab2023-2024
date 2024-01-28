using System.ComponentModel.DataAnnotations;

namespace PractiveRoom.Entities.DTO
{
    public class userDto
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string fullname { get; set; }
        public bool isActive { get; set; }
    }
}
