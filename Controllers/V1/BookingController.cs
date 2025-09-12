using System.Security.Claims;
using BookSystemApi.Dto.Book;
using BookSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookSystemApi.Controllers.V1
{

    [ApiController]
    [Route("api/v1/")]
    public class BookingController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookingController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Authorize]
        [HttpPost("booking/raw")]
        public async Task<IActionResult> AddBookingAsynRaw([FromBody] ReqBookJson reqBook)
        {
            try
            {
                Console.WriteLine("JSON :" + System.Text.Json.JsonSerializer.Serialize(reqBook));
                Console.WriteLine("Puspose :" + reqBook.Purpose);
                var book = new ReqBook
                {
                    UserId = int.TryParse(User.FindFirst(ClaimTypes.Sid)?.Value, out var userId) ? userId : 0,
                    RoomId = reqBook.Room_Id,
                    StartTime = reqBook.Start_Time,
                    EndTime = reqBook.End_Time,
                    Purpose = reqBook.Purpose
                };

                Console.WriteLine("Book :"+ System.Text.Json.JsonSerializer.Serialize(book));
                var result = await _bookService.AddBookAsynRaw(book);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", detail = ex.Message });
            }
        }


    }
}