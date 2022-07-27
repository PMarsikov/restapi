using LibraryWebApiPavel.Models;
using LibraryWebApiPavel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApiPavel.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly LibraryContext _dbContext;

        public AuthorRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> GetObjectsAsync()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<Author> GetObject(int id)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Create(Author entity)
        {
            _dbContext.Authors.Add(entity);
        }

        public void Update(Author item)
        {
            _dbContext.Update(item);
        }

        public void Delete(Author item)
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