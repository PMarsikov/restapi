using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApiPavel.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AuthorId { get; set; }
    }
}
