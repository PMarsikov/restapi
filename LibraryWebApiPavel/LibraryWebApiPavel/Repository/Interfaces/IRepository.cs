using System.Collections.Generic;

namespace LibraryWebApiPavel.Repository.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        Task<IEnumerable<T>> GetObjectsAsync();
        Task<T> GetObject(int id);
        void Create(T item);
        Task SaveAsync();
        void Update(T item);
        void Delete(T item);
    }
}