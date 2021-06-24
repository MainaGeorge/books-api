using System.Collections;
using System.Collections.Generic;

namespace my_books.Data.Models
{
    public class AuthorToReturnDto
    {
        public string Name { get; init; }
        public int Id { get; init; } 
        public IEnumerable<string> Books { get; init; }
    }
}