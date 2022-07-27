using LibraryWebApiPavel.Models;
using LibraryWebApiPavel.Repository;
using LibraryWebApiPavel.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApiPavel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        LibraryContext db;
        private readonly IRepository<Book> _bookRepository;
        public BooksController(LibraryContext context)
        {
            db = context;
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
            }
            ;
            if (_bookRepository.GetObject(book.Id) == null)
            {
                return NotFound();
            }

            _bookRepository.Update(book);
            await _bookRepository.SaveAsync();
            return Ok(book);
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
            return Ok(book);
        }
    }
}