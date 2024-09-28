
using LibrarySystem.Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Library.Infrastructure;

// DbContext class to interact with the database for the Book entity
public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}