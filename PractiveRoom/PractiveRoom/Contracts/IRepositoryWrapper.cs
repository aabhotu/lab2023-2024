
namespace PractiveRoom.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IRoomRepository Room { get; }
        ISubjectRepository Subject { get; }
        ITeacherReposiroty Teacher { get; }
        IScheduleRepository Schedule { get; }
        void save();
    }
}
