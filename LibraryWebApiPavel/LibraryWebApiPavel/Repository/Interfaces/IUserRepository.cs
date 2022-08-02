using LibraryWebApiPavel.Models;

namespace LibraryWebApiPavel.Repository.Interfaces
{
    public interface IUserRepository<T> : IDisposable
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
