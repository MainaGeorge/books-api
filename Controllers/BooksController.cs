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

        [HttpGet("{bookId:int}")]
        public IActionResult GetBookById(int bookId)
        {
            var book = _bookService.GetBookById(bookId);

            if(book != null) return Ok(book);

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookManipulationModel model)
        {
            _bookService.AddBook(model);
            return Ok();
        }

        [HttpPut("{bookId:int}")]
        public IActionResult UpdateBook(int bookId, [FromBody]BookManipulationModel bookModel)
        {
            _bookService.UpdateBook(bookId, bookModel);

            return NoContent();
        }

        [HttpDelete("{bookId:int}")]
        public IActionResult DeleteBook(int bookId)
        {
            _bookService.DeleteBook(bookId);

            return NoContent();
        }
    }
}
