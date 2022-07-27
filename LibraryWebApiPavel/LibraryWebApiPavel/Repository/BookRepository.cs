using LibraryWebApiPavel.Models;
using LibraryWebApiPavel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApiPavel.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryContext _dbContext;

        public BookRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetObjectsAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetObject(int id)
        {
            return await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

        }

        public void Create(Book entity)
        {
            _dbContext.Books.Add(entity);
        }

        public void Update(Book item)
        {
            _dbContext.Update(item);
        }

        public void Delete(Book item)
        {
            _dbContext.Remove(item);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}