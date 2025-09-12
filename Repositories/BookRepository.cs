using BookSystemApi.Data;
using BookSystemApi.Dto.Book;
using BookSystemApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSystemApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddBookAsyncRaw(ReqBook book)
        {
            Console.WriteLine("Time: "+ book.StartTime);
            return await _context.Database.ExecuteSqlRawAsync(
                "INSERT INTO \"BOOKING\" (\"USER_ID\",\"ROOM_ID\",\"START_TIME\", \"END_TIME\", \"PURPOSE\") VALUES ({0},{1},CAST({2} AS TIMESTAMP),CAST({3} AS TIMESTAMP),{4})",
                book.UserId, book.RoomId, book.StartTime, book.EndTime, book.Purpose
            );

        }
    }
}