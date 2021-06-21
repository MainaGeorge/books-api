using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; } 
        
        public DbSet<Author> Authors { get; set; }

        public DbSet<AuthorBookJoinTable> AuthorBookJoinTable { get; set; }    
    }

}
