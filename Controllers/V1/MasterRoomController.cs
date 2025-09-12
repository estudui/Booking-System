using BookSystemApi.Dto.Room;
using BookSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSystemApi.Controllers.V1
{

    [ApiController]
    [Route("api/v1/master")]

    public class MasterRoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public MasterRoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("rooms/raw")]
        public async Task<IActionResult> GetAllRoomAsyncRaw()
        {
            try
            {
                var rooms = await _roomService.GetAllRoomAsyncRaw();
                return Ok(rooms);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound("Room not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                var custom = new CustomApiResult(
                        "99",
                        "Other Error",
                        "An error occurred",
                        String.Empty
                    );

                return BadRequest(custom);
                // return StatusCode(500, new { message = "An error occurred", detail = ex.Message });
            }
        }
        
        [Authorize]
        [HttpPost("rooms/raw")]
        public async Task<IActionResult> AddRoomAsynRaw([FromBody] ReqRoom reqRoom)
        {
            try
            {
                var result = await _roomService.AddRoomAsynRaw(reqRoom);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", detail = ex.Message });
            }
        }
    }
}