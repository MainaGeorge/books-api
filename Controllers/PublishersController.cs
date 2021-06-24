using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherService _service;

        public PublishersController(PublisherService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            var publishers = _service.GetPublishers();

            return Ok(publishers);
        }

        [HttpGet("{publisherId:int}")]
        public IActionResult GetPublisherById(int publisherId)
        {
           var publisher = _service.GetPublisherToReturnDto(publisherId);

           return Ok(publisher);
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherManipulationModel model)
        {
            _service.AddPublisher(model);

            return Ok();
        }

        [HttpDelete("{publisherId:int}")]
        public IActionResult DeletePublisher(int publisherId)
        {
            _service.DeletePublisher(publisherId);

            return NoContent();
        }

        [HttpPut("{publisherId:int}")]
        public IActionResult UpdatePublisher(int publisherId, PublisherManipulationModel model)
        {
            _service.UpdatePublisher(publisherId, model);

            return NoContent();
        }
    }
}
