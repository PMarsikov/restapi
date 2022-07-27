using LibraryWebApiPavel.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApiPavel.Repository.Interfaces
{
    public interface ILibraryContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
