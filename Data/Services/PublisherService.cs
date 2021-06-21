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

        public Publisher GetPublisherById(int publisherId) =>
            _context.Publishers.FirstOrDefault(p => p.Id.Equals(publisherId));

        public IEnumerable<Publisher> GetPublishers() => _context.Publishers.ToList();

        public void AddPublisher(PublisherManipulationModel model)
        {
            var publisher = new Publisher { Name = model.Name};

            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }

        public void DeletePublisher(int publisherId)
        {
            var publisher = GetPublisherById(publisherId);

            if (publisher == null) return;
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
        }

        public void UpdatePublisher(int publisherId, PublisherManipulationModel model)
        {
            var publisher = GetPublisherById(publisherId);

            if(publisher == null) return;

            publisher.Name = model.Name;

            _context.SaveChanges();
        }
    }
}
