//using LibraryWebApiPavel.Configs;
using LibraryWebApiPavel.Models;
using LibraryWebApiPavel.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApiPavel.Repository
{

    public class LibraryContext : DbContext, ILibraryContext
    {
       // private readonly Settings _settings;
        //private readonly Settings _settings;
        public DbSet<Book> Books { get; set; }
        //  public DbSet<Author> Authors { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
               Database.EnsureCreated();

        }

        public LibraryContext()
        {
         //   _settings = new Configs.Configs().GetConfig();
            //Database.EnsureDeleted();
         //   Database.EnsureCreated();

        }
    }

}
