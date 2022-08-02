using LibraryWebApiPavel.Dto;
using LibraryWebApiPavel.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApiPavel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksDetailsController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksDetailsController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetObjectsAsync()
        {
            try
            {
                var result = _bookService.GetBooksDetails();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
