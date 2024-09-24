
using LibrarySystem.Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Library.Infrastructure;


public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}