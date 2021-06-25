using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models
{
    public class BookForReturningDto
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public string CoverUrl { get; set; }
        public int? Rate { get; set; }
        public int Id { get; set; }
        public string Publisher { get; set; }
        public IEnumerable<string> Authors { get; set; }
    }
}
