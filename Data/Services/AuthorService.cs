using System.Collections.Generic;
using System.Linq;
using my_books.Data.Models;

namespace my_books.Data.Services
{
    public class AuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public Author GetAuthorById(int authorId) => _context.Authors.FirstOrDefault(
            a => a.Id == authorId);

        public IEnumerable<Author> GetAuthors() => _context.Authors.ToList();

        public void AddAuthor(AuthorViewModel authorModel)
        {
            var author = new Author {FullName = authorModel.FullName};

            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int authorId)
        {
            var author = GetAuthorById(authorId);

            if (author == null) return;

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(int authorId, AuthorViewModel model)
        {
            var author = GetAuthorById(authorId);

            if (author == null) return;

            author.FullName = model.FullName;

            _context.SaveChanges();
        }
    }
}
