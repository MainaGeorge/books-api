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

        [HttpGet("{publisherId:int}", Name = "GetPublisherById")]
        public IActionResult GetPublisherById(int publisherId)
        {
           var publisher = _service.GetPublisherToReturnDto(publisherId);

           if (publisher == null) return NotFound();

           return Ok(publisher);
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherManipulationModel model)
        {
            var publisher = _service.AddPublisher(model);

            return CreatedAtAction("GetPublisherById", new {publisherId = publisher.Id}, publisher);
        }

        [HttpDelete("{publisherId:int}")]
        public IActionResult DeletePublisher(int publisherId)
        {
            if(_service.DeletePublisher(publisherId)) return NoContent();

            return NotFound($"The publisher with id {publisherId} is not in the database");
        }

        [HttpPut("{publisherId:int}")]
        public IActionResult UpdatePublisher(int publisherId, PublisherManipulationModel model)
        {
            if(!_service.UpdatePublisher(publisherId, model)) return NotFound();

            return NoContent();
        }
    }
}
