using Microsoft.EntityFrameworkCore;
using PractiveRoom.Contracts;
using RestApi.Contracts;
using RestApi.Entities;
using RestApi.Repository;

namespace PractiveRoom.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _context;
        private IUserRepository _user;
        
        public RepositoryWrapper(RepositoryContext context)
        {
            _context = context;
        }
        public void save()
        {
            _context.SaveChanges();
        }
        public IUserRepository User
        {
            get
            {
                if (_user != null)
                {
                    return _user;
                }
                return new UserRepository(_context);
            }
        }
    }
}
