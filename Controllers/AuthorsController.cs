using System;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _service;

        public AuthorsController(AuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            var authors = _service.GetAuthors();

            return Ok(authors);
        }

        [HttpGet("{authorId:int}", Name = "GetAuthorById")]
        public IActionResult GetAuthorById(int authorId)
        {
            var author = _service.GetAuthorToReturnDtoById(authorId);

            if (author == null) return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorManipulationModel model)
        {
            var createdAuthor = _service.AddAuthor(model);

            return CreatedAtRoute("GetAuthorById", 
                new {authorId = createdAuthor.Id}, createdAuthor);
        }

        [HttpDelete("{authorId:int}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            if(!_service.DeleteAuthor(authorId)) return NotFound();

            return NoContent();
        }

        [HttpPut("{authorId:int}")]
        public IActionResult UpdateAuthor(int authorId, AuthorManipulationModel model)
        {
            if(!_service.UpdateAuthor(authorId, model)) return NotFound();

            return NoContent();
        }
    }
}
