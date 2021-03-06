using System.Collections.Generic;
using System.Linq;
using my_books.Data.Models;

namespace my_books.Data.Services
{
    public class PublisherService
    {
        private readonly AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        private Publisher GetPublisherById(int publisherId) =>
            _context.Publishers.FirstOrDefault(p => p.Id.Equals(publisherId));

        public PublisherToReturnDto GetPublisherToReturnDto(int publisherId)
        {
            return 
                _context.Publishers.Where(p => p.Id.Equals(publisherId))
                    .Select(p => new PublisherToReturnDto
                    {
                        Name = p.Name,
                        Id = p.Id,
                        PublishedBooks = p.Books.Select(b => b.Title).ToList()
                    })
                    .FirstOrDefault();
        }
        public IEnumerable<PublisherToReturnDto> GetPublishers() => _context.Publishers
            .Select(p => new PublisherToReturnDto
            {
                Name = p.Name,
                Id = p.Id,
                PublishedBooks = p.Books.Select(b => b.Title).ToList()
            }).ToList();

        public PublisherToReturnDto AddPublisher(PublisherManipulationModel model)
        {
            var publisher = new Publisher { Name = model.Name};

            _context.Publishers.Add(publisher);
            _context.SaveChanges();

            return new PublisherToReturnDto
            {
                Id = publisher.Id,
                Name = publisher.Name,
            };
        }

        public bool DeletePublisher(int publisherId)
        {
            var publisher = GetPublisherById(publisherId);

            if (publisher == null) return false;
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();

            return true;
        }

        public bool UpdatePublisher(int publisherId, PublisherManipulationModel model)
        {
            var publisher = GetPublisherById(publisherId);

            if(publisher == null) return false;

            publisher.Name = model.Name;

            _context.SaveChanges();

            return true;
        }
    }
}
