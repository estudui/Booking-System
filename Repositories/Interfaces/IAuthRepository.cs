using BookSystemApi.Dto.User;

namespace BookSystemApi.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<UserAuthDto?> GetUserAsyncRaw(string email);
        Task<int> AddUserAsyncRaw(UserDto user);
    }
}