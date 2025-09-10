using BookSystemApi.Dto.Room;
using BookSystemApi.Entities;

namespace BookSystemApi.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Rooms>> GetRoomAsyncRaw();
        Task<int> AddRoomAsyncRaw(ReqRoom room);
    }
}