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

        public AuthorToReturnDto GetAuthorToReturnDtoById(int authorId) => _context.Authors
            .Where(a => a.Id.Equals(authorId))
            .Select(a => new AuthorToReturnDto
            {
                Name = a.FullName,
                Id = a.Id,
                Books = a.Books.Select(b => b.Book.Title).ToList()
            })
            .FirstOrDefault();

        private Author GetAuthorById(int authorId) => _context.Authors.Find(authorId);
        public IEnumerable<AuthorToReturnDto> GetAuthors() => _context.Authors
            .Select(a => new AuthorToReturnDto{
                Name = a.FullName,
                Id = a.Id,
                Books = a.Books.Select(b => b.Book.Title).ToList()
            }).ToList();
        public void AddAuthor(AuthorManipulationModel authorModel)
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

        public void UpdateAuthor(int authorId, AuthorManipulationModel model)
        {
            var author = GetAuthorById(authorId);

            if (author == null) return;

            author.FullName = model.FullName;

            _context.SaveChanges();
        }
    }
}
