using LibrarySystem.Library.Contracts.Exceptions;
using LibrarySystem.Library.Domain.Entities;
using LibrarySystem.Library.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Library.Application.Commands.Books.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly BooksDbContext _booksDbContext; 
    
    //constructor
    public UpdateBookCommandHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }

    //handles the update command of a book from the database
    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var BookUpdate = await _booksDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        
        if (BookUpdate is null)
        {
            throw new NotFoundExceptions($"{nameof(Book)} with {nameof(Book.Id)}: {request.Id}" + $"was not found in the Library");
        }

        BookUpdate.Title = request.Title;
        BookUpdate.Description = request.Description;   
        BookUpdate.Author = request.Author; 

        _booksDbContext.Books.Update(BookUpdate);
        await _booksDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
           
        //throw new NotImplementedException();
    }
}
