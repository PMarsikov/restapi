using AutoMapper;
using LibraryWebApiPavel.Dto;
using LibraryWebApiPavel.Models;
using LibraryWebApiPavel.Repository;
using LibraryWebApiPavel.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApiPavel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        LibraryContext db;
        private readonly IMapper _mapper;
        private readonly IRepository<Book> _bookRepository;
        public BooksController(LibraryContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
            this._bookRepository = new BookRepository(db);
        }

        [HttpGet]
        public async Task<IActionResult> GetObjectsAsync()
        {
            try
            {
                var books = await _bookRepository.GetObjectsAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            Book book = await _bookRepository.GetObject(id);
            if (book == null)
                return NotFound();
            return new ObjectResult(book);
        }

        // POST api/books
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            _bookRepository.Create(book);
            await _bookRepository.SaveAsync();
            return Ok(book);
        }

        // PUT api/books/
        [HttpPut]
        public async Task<ActionResult<Book>> Put(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            };
            var bookById = await _bookRepository.GetObject(book.Id);
            if (bookById == null)
            {
                return NotFound();
            }
            _bookRepository.Update(book);
            await _bookRepository.SaveAsync();
            return NoContent();
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(int id)
        {
            Book book = await _bookRepository.GetObject(id);
            if (book == null)
            {
                return NotFound();
            }

            _bookRepository.Delete(book);
            await _bookRepository.SaveAsync();
            return NoContent();
        }
    }
}