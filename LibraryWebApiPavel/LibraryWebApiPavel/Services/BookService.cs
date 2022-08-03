using LibraryWebApiPavel.Dto;
using LibraryWebApiPavel.Repository;
using LibraryWebApiPavel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApiPavel.Services
{
    public class BookService: IBookService
    {
        private DbContextOptions<LibraryContext> _dbContextOptions;


        public BookService(DbContextOptions<LibraryContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public List<BookDetailDto> GetBooksDetails()
        {
            using (var db = new LibraryContext(_dbContextOptions))
            {
                Console.WriteLine();

                var result = db.Books.Join(db.Authors,
                    b => b.AuthorId,
                    a => a.Id,
                    (b, a) => new BookDetailDto
                    {
                        Title = b.Title,
                        BookYear = b.BookYear,
                        AuthorFirstName = a.AuthorFirstName,
                        AuthorMiddleName = a.AuthorMiddleName,
                        AuthorLastName = a.AuthorLastName,
                        AuthorBirthDay = a.AuthorBirthDay
                    }).ToList();
                return result;
            }
        }
  
    }
}
