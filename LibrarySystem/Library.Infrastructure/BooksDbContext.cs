
using LibrarySystem.Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Library.Infrastructure;


public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}