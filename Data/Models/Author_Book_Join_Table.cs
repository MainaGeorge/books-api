using System.ComponentModel.DataAnnotations.Schema;

namespace my_books.Data.Models
{
    public class AuthorBookJoinTable
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }  
    }
}
