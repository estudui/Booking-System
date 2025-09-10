using BookSystemApi.Data;
using BookSystemApi.Dto.Room;
using BookSystemApi.Entities;
using BookSystemApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSystemApi.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Rooms>> GetRoomAsyncRaw()
        {
            return await _context.Set<Rooms>().FromSqlRaw(
                "SELECT * FROM \"ROOM\""
            ).ToListAsync();
        }

        public async Task<int> AddRoomAsyncRaw(ReqRoom room)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "INSERT INTO \"ROOM\" (\"NAME\",\"LOCATION\",\"CAPACITY\") VALUES ({0},{1},{2})",
                room.Name, room.Location, room.Capacity
            );

        }
    }
}