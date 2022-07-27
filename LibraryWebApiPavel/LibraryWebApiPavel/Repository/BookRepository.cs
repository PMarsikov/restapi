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

        /* public IEnumerable<Book> GetObjects()
         {
             try
             {
                 return _dbContext.Books.ToList();
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 return Enumerable.Empty<Book>();
             }

         }*/

        public async Task<IEnumerable<Book>> GetObjectsAsync()
        {
            return await _dbContext.Books.ToListAsync();
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

        /*
                public void Create(Book entity)
                {
                    _dbContext.Books.Add(entity);
                }


                public Book GetObject(int id)
                {
                    throw new NotImplementedException();
                }

                public void Update(Book item)
                {
                    throw new NotImplementedException();
                }

                public void Delete(int id)
                {
                    throw new NotImplementedException();
                }

                public void Save()
                {
                    _dbContext.SaveChanges();
                }
                */
    }
}
