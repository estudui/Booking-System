using BookSystemApi.Data;
using BookSystemApi.Dto.User;
using BookSystemApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookSystemApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserAuthDto?> GetUserAsyncRaw(string email)
        {
            return await _context.Set<UserAuthDto>().FromSqlRaw(
                "SELECT * FROM \"APP_USER\" WHERE \"EMAIL\" = {0}", email
            ).FirstAsync();
        }

        public async Task<int> AddUserAsyncRaw(UserDto user)
        {
            return await _context.Database.ExecuteSqlRawAsync(
                "INSERT INTO \"APP_USER\" (\"FULL_NAME\",\"EMAIL\",\"PASSWORD_HASH\",\"DIVISION_ID\",\"POSITION_ID\") VALUES ({0},{1},{2},{3},{4})",
                user.Full_Name, user.Email, user.Password_Hash, user.Division_id, user.Position_id
            );

        }
    }
}