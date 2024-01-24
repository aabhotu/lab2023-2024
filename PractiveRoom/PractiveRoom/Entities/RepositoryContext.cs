using Microsoft.EntityFrameworkCore;
using PractiveRoom.Models;
using RestApi.Models;

namespace RestApi.Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base (options) 
        { }
        public DbSet<User> users { set; get; }
        public DbSet<Room> rooms { set; get; }
        
    }
}
