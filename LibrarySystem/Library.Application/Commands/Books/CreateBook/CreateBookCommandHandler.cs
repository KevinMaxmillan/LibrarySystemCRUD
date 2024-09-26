using System.Reflection;
using LibrarySystem.Library.Domain.Entities;
using LibrarySystem.Library.Infrastructure;
using MediatR;


namespace LibrarySystem.Library.Application.Commands.Books.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int> 
{
    private readonly BooksDbContext _booksDbContext;
    public CreateBookCommandHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var books = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Description = request.Description
          
        };

        await _booksDbContext.Books.AddAsync(books, cancellationToken);
        var id = await _booksDbContext.SaveChangesAsync(cancellationToken);

        return id;
    }
}

