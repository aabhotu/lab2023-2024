using PractiveRoom.Models;

namespace PractiveRoom.Contracts
{
    public interface IRoomRepository: IRepositoryBase<Room>
    {
        IEnumerable<Room> GetAllRoom();
        Room GetRoomById(int id);
        void CreateRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(Room room);
    }
}
