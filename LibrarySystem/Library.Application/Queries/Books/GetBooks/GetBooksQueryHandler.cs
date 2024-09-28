using LibrarySystem.Library.Contracts.Responses;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Library.Infrastructure;
using MediatR;
using Mapster;

namespace LibrarySystem.Library.Application.Queries.Books.GetBooks;

//handler for retrieveing the list of books
public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, GetBooksResponse>
{
    //dependancy from the database
    private readonly BooksDbContext _booksDbContext;

    //constructor
    public GetBooksQueryHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }

    // Asynchronously retrieve all books from the database
    public async Task<GetBooksResponse> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        
        //var books = await _booksDbContext.Books>ToListAsync(cancellationToken).ConfigureAwait(false);
        var Books = await _booksDbContext.Books.ToArrayAsync(cancellationToken);
        //throw new NotImplementedException();

        // Map the retrieved book entities to the GetBooksResponse using Mapster
        return Books.Adapt<GetBooksResponse>();
    }
}
