using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetBooks();

            return Ok(books);
        }

        [HttpGet("{bookId:int}", Name = "GetBookById")]
        public IActionResult GetBookToReturnById(int bookId)
        {
            var book = _bookService.GetBookToReturnById(bookId);

            if(book != null) return Ok(book);

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookForCreationDto model)
        {
            var createdBook = _bookService.AddBook(model);
            return CreatedAtRoute("GetBookById", new {bookId = createdBook.Id}, createdBook);
        }

        [HttpPut("{bookId:int}")]
        public IActionResult UpdateBook(int bookId, [FromBody]BookForCreationDto bookModel)
        {
            if(!_bookService.UpdateBook(bookId, bookModel)) return NotFound();

            return NoContent();
        }

        [HttpDelete("{bookId:int}")]
        public IActionResult DeleteBook(int bookId)
        {
            if(!_bookService.DeleteBook(bookId)) return NotFound();

            return NoContent();
        }
    }
}
