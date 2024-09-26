using System.Data.Entity;
using LibrarySystem.Library.Infrastructure;
using MediatR;

namespace LibrarySystem.Library.Application.Commands.Books.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly BooksDbContext _booksDbContext;
    public DeleteBookCommandHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }
    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var BookDelete = await _booksDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.id, cancellationToken);
        
        if (BookDelete is null) 
        {
            throw new Exception();
        }

        _booksDbContext.Books.Remove(BookDelete);
        await _booksDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }
}
