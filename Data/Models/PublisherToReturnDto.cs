using System.Collections.Generic;

namespace my_books.Data.Models
{
    public class PublisherToReturnDto
    {
        public string Name { get; init; }
        public List<string> PublishedBooks { get; init; }

        public int Id { get; set; }
    }
}