using BookSystemApi.Dto.User;
using BookSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookSystemApi.Controllers.V1
{

    [ApiController]
    [Route("api/v1/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("user/raw")]
        public async Task<IActionResult> AddUserAsynRaw([FromBody] ReqUser reqUser)
        {
            try
            {
                var user = new UserDto
                {
                    Email = reqUser.Email,
                    Password_Hash = reqUser.Password,
                    Full_Name = reqUser.Full_Name,
                    Position_id = reqUser.Position_id,
                    Division_id = reqUser.Division_id
                };

                var result = await _userService.AddUserAsynRaw(user);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", detail = ex.Message });
            }
        }

        [HttpPost("user/login")]
        public async Task<IActionResult> LoginAsync([FromBody] ReqLoginDto loginDto)
        {
            var token = await _userService.LoginAsync(loginDto);

            if (token == null)
            {
                var custom = new CustomApiResult(
                        "01",
                        "Login Failed",
                        "Email or Password is incorrect",
                        String.Empty
                    );

                return Unauthorized(custom);
            }

            return Ok(new { token });
        }

    }
}