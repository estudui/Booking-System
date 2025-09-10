using BookSystemApi.Dto.Room;
using BookSystemApi.Entities;
using BookSystemApi.Repositories.Interfaces;
using BookSystemApi.Services.Interfaces;

namespace BookSystemApi.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Rooms>> GetAllRoomAsyncRaw()
        {
            var room = await _roomRepository.GetRoomAsyncRaw();
            if (room == null)
            {
                throw new KeyNotFoundException("Room not found");
            }
            return room;
        }

        public async Task<string> AddRoomAsynRaw(ReqRoom room)
        {
            var insert = await _roomRepository.AddRoomAsyncRaw(room);
            return insert > 0 ? "Success" : "Failed";
        }
    }
}