using System.Collections.Generic;

namespace LibraryWebApiPavel.Repository.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        //public IEnumerable<T> GetObjectsAsync();
        Task<IEnumerable<T>> GetObjectsAsync();
        /*  T GetObject(int id);
          void Create(T item);
          void Update(T item);
          void Delete(int id);
          void Save();*/
    }
}
