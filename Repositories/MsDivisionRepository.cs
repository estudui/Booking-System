using BookSystemApi.Data;
using BookSystemApi.Dto.Division;
using BookSystemApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSystemApi.Repositories
{
    public class MsDivisionRepository : IMsDivisionRepository
    {
        private readonly ApplicationDbContext _context;

        public MsDivisionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DivisionDto>> GetDivisionAsyncRaw()
        {
            return await _context.Set<DivisionDto>().FromSqlRaw(
                "SELECT * FROM \"DIVISION\""
            ).ToListAsync();
        }

        public async Task<int> AddDivisionAsyncRaw(string name)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "INSERT INTO \"DIVISION\" (\"NAME\") VALUES ({0})",
                name
            );

        }
    }
}