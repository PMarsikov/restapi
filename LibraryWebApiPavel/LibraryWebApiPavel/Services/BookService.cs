using LibraryWebApiPavel.Dto;
using LibraryWebApiPavel.Repository;
using LibraryWebApiPavel.Services.Interfaces;

namespace LibraryWebApiPavel.Services
{
    public class BookService : IBookService, IDisposable
    {
        private readonly LibraryContext _dbContext;

        public BookService(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookDetailDto GetBooksDetails()
        {
            var result = _dbContext.Books.AsEnumerable().Join(_dbContext.Authors,
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
                });
            return (BookDetailDto)result;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }

        private bool disposed = false;
    }
}
