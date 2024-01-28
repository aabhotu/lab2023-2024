using Microsoft.EntityFrameworkCore;
using PractiveRoom.Contracts;
using PractiveRoom.Entities;
using PractiveRoom.Models;
using System.Collections;

namespace PractiveRoom.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repoContext) : base(repoContext) { }
        public IEnumerable<User> GetAllUser()
        {
            return All().OrderBy(i => i.username).ToList();
        }
        public User GetUserById(Guid Id)
        {
            return Find(u => u.id.Equals(Id)).FirstOrDefault();
        }
        public void CreateUser(User user) => Create(user);
        public void UpdateUser(User user) => Update(user);
        public void DeleteUser(User user) => Delete(user);
    }
}
