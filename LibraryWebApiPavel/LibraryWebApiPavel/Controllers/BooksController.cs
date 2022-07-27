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
            /*   if (!db.Books.Any())  //db.Books.Any()
               {
                   //   
                   db.Books.Add(new Book { Title = "1111", CreatedDate = new DateTime(2019, 05, 09, 09, 15, 00), AuthorId = 1 });
                   db.Books.Add(new Book { Title = "22222", CreatedDate = new DateTime(2019, 05, 09, 09, 15, 00), AuthorId = 1 });
                   db.SaveChanges();
               }*/
        }


        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetObjectsAsync()
        {
            
            var owners = await _bookRepository.GetObjectsAsync();
            return await owners.ToListAsync()//await db.Books.ToListAsync();
        }
        98*/
        [HttpGet]
        public async Task<IActionResult> GetObjectsAsync()
        {
            try
            {
                var books = await _bookRepository.GetObjectsAsync();
                /*_logger.LogInfo($"Returned all owners from database.");
                var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);*/
                return Ok(books);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }



        /*
              [HttpGet]
              public async Task<ActionResult<IEnumerable<Book>>> Get()
              {
                  return await db.Books.ToListAsync();
              }


              // GET api/books/5
              [HttpGet("{id}")]
              public async Task<ActionResult<Book>> Get(int id)
              {
                  Book book = await db.Books.FirstOrDefaultAsync(x => x.Id == id);
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

                  db.Books.Add(book);
                  await db.SaveChangesAsync();
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
                  if (!db.Books.Any(x => x.Id == book.Id))
                  {
                      return NotFound();
                  }

                  db.Update(book);
                  await db.SaveChangesAsync();
                  return Ok(book);
              }

              // DELETE api/books/5
              [HttpDelete("{id}")]
              public async Task<ActionResult<Book>> Delete(int id)
              {
                  Book book = db.Books.FirstOrDefault(x => x.Id == id);
                  if (book == null)
                  {
                      return NotFound();
                  }
                  db.Books.Remove(book);
                  await db.SaveChangesAsync();
                  return Ok(book);
              }

              */
    }
}
