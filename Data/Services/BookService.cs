using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace my_books.Data.Services
{
    public class BookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }


        public void AddBook(BookForCreationDto model)
        {
            var book = new Book()
            {
                Description = model.Description,
                Title = model.Title,
                IsRead = model.IsRead,
                DateRead = model.DateRead,
                DateAdded = DateTime.Now,
                Genre = model.Genre,
                Rate = model.Rate,
                CoverUrl = model.CoverUrl,
                PublisherId = model.PublisherId
            };

            _context.Books.Add(book);
            _context.SaveChanges();


            if (!model.AuthorIds.Any()) return;

            foreach (var authorId in model.AuthorIds)
            {
                var authorBookJoinTable = new AuthorBookJoinTable
                {
                    BookId = book.Id,
                    AuthorId = authorId
                };

                _context.AuthorBookJoinTable.Add(authorBookJoinTable);
            }

            _context.SaveChanges();
        }

        public List<BookForReturningDto> GetBooks()
        {
            
            return _context.Books
                .Select(b => new BookForReturningDto
                {
                    Title = b.Title,
                    Genre = b.Genre,
                    Description = b.Description,
                    IsRead = b.IsRead,
                    DateRead = b.DateRead,
                    CoverUrl = b.CoverUrl,
                    Rate = b.Rate,
                    Publisher = b.Publisher.Name,
                    Authors = b.Authors.Select(a => a.Author.FullName).ToList()
                }).ToList();
        }

        public BookForReturningDto GetBookToReturnById(int bookId)
        {
            var book = _context.Books
                .Where(b => b.Id.Equals(bookId))
                .Select(b => new BookForReturningDto
                {
                    Title = b.Title,
                    Genre = b.Genre,
                    Description = b.Description,
                    IsRead = b.IsRead,
                    DateRead = b.DateRead,
                    CoverUrl = b.CoverUrl,
                    Rate = b.Rate,
                    Publisher = b.Publisher.Name,
                    Authors = b.Authors.Select(a => a.Author.FullName).ToList()
                })
                .FirstOrDefault();

            return book;
        }

        private Book GetBookById(int id) => _context.Books.Find(id);

        public void UpdateBook(int bookId, BookForCreationDto bookModel)
        {
            if (bookModel == null)
                throw new ArgumentNullException(nameof(bookModel), "this argument can not be null");

            var book = GetBookById(bookId);

            if (book == null)
                throw new ArgumentNullException(nameof(book), "this argument can not be null");

            book.Description = bookModel.Description ?? book.Description;
            book.CoverUrl = bookModel.CoverUrl ?? book.CoverUrl;
            book.DateRead = bookModel.DateRead ?? book.DateRead;
            book.Rate = bookModel.Rate ?? book.Rate;
            book.Genre = bookModel.Genre ?? book.Genre;
            book.IsRead = bookModel.IsRead;
            book.Title = bookModel.Title ?? book.Title;

            _context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = GetBookById(bookId);

            if (book == null) return;

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
