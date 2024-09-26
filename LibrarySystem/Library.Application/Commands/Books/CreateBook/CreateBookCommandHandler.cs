
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
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Description = request.Description,
            CreateDate = DateTime.Now.ToUniversalTime()

        };

        await _booksDbContext.Books.AddAsync(book, cancellationToken);
        await _booksDbContext.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}

