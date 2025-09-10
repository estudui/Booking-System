using BookSystemApi.Dto.Room;
using BookSystemApi.Entities;

namespace BookSystemApi.Services.Interfaces
{
    public interface IRoomService
    {
        Task<IEnumerable<Rooms>> GetAllRoomAsyncRaw();
        Task<string> AddRoomAsynRaw(ReqRoom room);
    }
}