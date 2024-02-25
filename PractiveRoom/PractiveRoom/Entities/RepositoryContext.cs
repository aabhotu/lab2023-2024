using Microsoft.EntityFrameworkCore;
using PractiveRoom.Models;

namespace PractiveRoom.Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base (options) 
        { }
        public DbSet<User> users { set; get; }
        public DbSet<Room> rooms { set; get; }
        public DbSet<Teacher> teachers { set; get; }
        public DbSet<Subject> subjects { set; get; }
        public DbSet<Schedule> schedules { set; get; }
        public DbSet<StudentSchedule> studentSchedule { set; get; }
        
    }
}
