using System;
using System.Collections.Generic;

namespace my_books.Data.Models
{
    public class BookForCreationDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public string CoverUrl { get; set; }
        public int? Rate { get; set; }

        public int PublisherId { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }
    }
}