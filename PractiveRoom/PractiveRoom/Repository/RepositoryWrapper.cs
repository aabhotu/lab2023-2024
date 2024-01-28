using Microsoft.EntityFrameworkCore;
using PractiveRoom.Contracts;
using PractiveRoom.Entities;

namespace PractiveRoom.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _context;
        private IUserRepository _user;
        private IRoomRepository _room;
        private ITeacherReposiroty _teacher;
        private IScheduleRepository _schedule;

        ISubjectRepository _subject;
        
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
        public IRoomRepository Room
        {
            get
            {
                if(_room != null)
                    return _room;
                return new RoomRepository(_context);
            }
        }
        public ISubjectRepository Subject
        {
            get
            {
                if (_subject != null)
                    return _subject;
                return new SubjectRepository(_context);
            }
        }
        public ITeacherReposiroty Teacher
        {
            get
            {
                if (_teacher != null)
                    return _teacher;
                return new TeacherRepository(_context);
            }
        }
        public IScheduleRepository Schedule
        {
            get
            {
                if (_schedule != null)
                    return _schedule;
                return new ScheduleRepository(_context);
            }
        }
    }
}
