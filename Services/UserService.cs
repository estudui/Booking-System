using BookSystemApi.Dto.User;
using BookSystemApi.Repositories.Interfaces;
using BookSystemApi.Services.Interfaces;

namespace BookSystemApi.Services
{
    public class UserService : IUserService
    {
        private readonly IAuthRepository _userRepository;
        private readonly TokenService _tokenService;

        public UserService(IAuthRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<string?> LoginAsync(ReqLoginDto loginDto)
        {
            var user = await _userRepository.GetUserAsyncRaw(loginDto.Email);
            if (user == null) return null;

            // verifikasi password hash
            bool isValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password_Hash);
            if (!isValid) return null;

            return _tokenService.GenerateToken(user.Email, user.Full_Name, user.Id.ToString());
        }

        public async Task<string> AddUserAsynRaw(UserDto user)
        {
            user.Password_Hash = BCrypt.Net.BCrypt.HashPassword(user.Password_Hash);
            var insert = await _userRepository.AddUserAsyncRaw(user);
            return insert > 0 ? "Success" : "Failed";
        }

    }
}