using System.Data.Entity;
using LibrarySystem.Library.Contracts.Exceptions;
using LibrarySystem.Library.Domain.Entities;
using LibrarySystem.Library.Infrastructure;
using MediatR;

namespace LibrarySystem.Library.Application.Commands.Books.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit> 
{
    private readonly BooksDbContext _booksDbContext;

    //constructor
    public DeleteBookCommandHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }

    //handles the command of deleting a book from the database
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var BookDelete = await _booksDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        
        if (BookDelete is null) 
        {
            throw new NotFoundExceptions($"{nameof(Book)} with {nameof(Book.Id)}: {request.Id}" + $"was not found in the Library");
        }

        _booksDbContext.Books.Remove(BookDelete);
        await _booksDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}
