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


        public void AddBook(BookManipulationModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Description = model.Description,
                Author = model.Author,
                IsRead = model.IsRead,
                DateRead = model.DateRead,
                DateAdded = DateTime.Now,
                Genre = model.Genre,
                Rate = model.Rate,
                CoverUrl = model.CoverUrl
            };

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public List<Book> GetBooks() => _context.Books.ToList();

        public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(b => b.Id == bookId);

        public void UpdateBook(int bookId, BookManipulationModel bookModel)
        {
            if (bookModel == null)
                throw new ArgumentNullException(nameof(bookModel), "this argument can not be null");

            var book = GetBookById(bookId);

            if (book == null)
                throw new ArgumentNullException(nameof(book), "this argument can not be null");

            book.Title = bookModel.Title ?? book.Title;
            book.Description = bookModel.Description ?? book.Description;
            book.Author = bookModel.Author ?? book.Author;
            book.CoverUrl = bookModel.CoverUrl ?? book.CoverUrl;
            book.DateRead = bookModel.DateRead ?? book.DateRead;
            book.Rate = bookModel.Rate ?? book.Rate;
            book.Genre = bookModel.Genre ?? book.Genre;
            book.IsRead = bookModel.IsRead;

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
