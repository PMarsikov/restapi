using LibraryWebApiPavel.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApiPavel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksDetailsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetObjectsAsync()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
