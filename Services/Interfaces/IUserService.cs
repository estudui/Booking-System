using BookSystemApi.Dto.User;

namespace BookSystemApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> AddUserAsynRaw(UserDto user);
        Task<string?> LoginAsync(ReqLoginDto loginDto);
    }
}