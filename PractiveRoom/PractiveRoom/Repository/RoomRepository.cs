using PractiveRoom.Contracts;
using PractiveRoom.Entities;
using PractiveRoom.Models;

namespace PractiveRoom.Repository
{
    public class RoomRepository: RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(RepositoryContext context) : base(context) { }
        public IEnumerable<Room> GetAllRoom()
        {
            return All().OrderBy(i=> i.roomName).ToList();
        }
        public Room GetRoomById(int id)
        {
            return Find(i => i.roomId == id).FirstOrDefault();
        }
        public void CreateRoom(Room room) => Create(room);
        public void UpdateRoom(Room room) => Update(room);
        public void DeleteRoom(Room room) => Delete(room);

    }
}
