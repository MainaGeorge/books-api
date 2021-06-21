using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _service;

        public AuthorController(AuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _service.GetAuthors();

            return Ok(authors);
        }

        [HttpGet("{authorId:int}")]
        public IActionResult GetAuthorById(int authorId)
        {
            var author = _service.GetAuthorById(authorId);

            return Ok(author);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorViewModel model)
        {
            _service.AddAuthor(model);

            return Ok();
        }

        [HttpDelete("{authorId:int}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            _service.DeleteAuthor(authorId);

            return NoContent();
        }

        [HttpPut("{authorId:int}")]
        public IActionResult UpdateAuthor(int authorId, AuthorViewModel model)
        {
            _service.UpdateAuthor(authorId, model);

            return NoContent();
        }
    }
}
