
using LibrarySystem.Library.Domain.Entities;
using LibrarySystem.Library.Infrastructure;
using MediatR;


namespace LibrarySystem.Library.Application.Commands.Books.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int> 
{
    private readonly BooksDbContext _booksDbContext;

    //constructor
    public CreateBookCommandHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }

    //handles the command by creating the new book and saving it to the database
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        //new book entity
        var book = new Book
        {
            Title = request.Title,
            Author = request.Author,
            Description = request.Description,
            CreateDate = DateTime.Now.ToUniversalTime()

        };
        // addtion of the entity to the database 
        await _booksDbContext.Books.AddAsync(book, cancellationToken);
        await _booksDbContext.SaveChangesAsync(cancellationToken);

        return book.Id;
    }
}

