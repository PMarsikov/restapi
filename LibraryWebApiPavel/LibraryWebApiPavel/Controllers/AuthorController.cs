using LibraryWebApiPavel.Models;
using LibraryWebApiPavel.Repository;
using LibraryWebApiPavel.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApiPavel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
		LibraryContext db;
		private readonly IRepository<Author> _authorRepository;
		public AuthorController(LibraryContext context)
		{
			db = context;
			this._authorRepository = new AuthorRepository(db);
		}

		[HttpGet]
		public async Task<IActionResult> GetObjectsAsync()
		{
			try
			{
				var authors = await _authorRepository.GetObjectsAsync();
				return Ok(authors);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Internal server error");
			}
		}

		// GET api/authors/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Author>> Get(int id)
		{
			Author author = await _authorRepository.GetObject(id);
			if (author == null)
				return NotFound();
			return new ObjectResult(author);
		}

		// POST api/authors
		[HttpPost]
		public async Task<ActionResult<Author>> Post(Author author)
		{
			if (author == null)
			{
				return BadRequest();
			}
			_authorRepository.Create(author);
			await _authorRepository.SaveAsync();
			return Ok(author);
		}

		// PUT api/authors/
		[HttpPut]
		public async Task<ActionResult<Author>> Put(Author author)
		{
			if (author == null)
			{
				return BadRequest();
			};
			var authorId = await _authorRepository.GetObject(author.Id);
			if (authorId == null)
			{
				return NotFound();
			}

			_authorRepository.Update(author);
			await _authorRepository.SaveAsync();
			return NoContent();
		}

		// DELETE api/authors/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Author>> Delete(int id)
		{
			Author author = await _authorRepository.GetObject(id);
			if (author == null)
			{
				return NotFound();
			}

			_authorRepository.Delete(author);
			await _authorRepository.SaveAsync();
			return NoContent();
		}
	}
}
