using RestApi.Contracts;

namespace PractiveRoom.Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void save();
    }
}
