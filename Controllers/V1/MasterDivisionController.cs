using BookSystemApi.Dto.Division;
using BookSystemApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookSystemApi.Controllers.V1
{

    [ApiController]
    [Route("api/v1/master")]
    public class MasterDivisionController : ControllerBase
    {
        private readonly IMsDivisionService _divisionService;

        public MasterDivisionController(IMsDivisionService divisionService)
        {
            _divisionService = divisionService;
        }

        [HttpGet("divisions/raw")]
        public async Task<IActionResult> GetAllDivisionAsyncRaw()
        {
            try
            {
                var divisions = await _divisionService.GetAllDivisionAsyncRaw();
                return Ok(divisions);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound("Division not found: " + ex.Message);
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

        [HttpPost("divisions/raw")]
        public async Task<IActionResult> AddDivisionAsynRaw([FromBody] ReqDivisionDto reqDivision)
        {
            try
            {
                var result = await _divisionService.AddDivisionAsynRaw(reqDivision.Name);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", detail = ex.Message });
            }
        }
    }
}