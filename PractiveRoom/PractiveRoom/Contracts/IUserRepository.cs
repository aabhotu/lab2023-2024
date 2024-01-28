using PractiveRoom.Models;
using System.Collections;

namespace PractiveRoom.Contracts
{
    public interface IUserRepository :IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUser();
        User GetUserById(Guid Id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
