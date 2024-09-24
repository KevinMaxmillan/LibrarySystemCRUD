using LibrarySystem.Library.Contracts.Responses;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Library.Infrastructure;
using MediatR;
using Mapster;

namespace LibrarySystem.Library.Application.Queries.Books.GetBooks;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, GetBooksResponse>
{
    private readonly BooksDbContext _booksDbContext;
    public GetBooksQueryHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }
    public async Task<GetBooksResponse> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        
        //var books = await _booksDbContext.Books>ToListAsync(cancellationToken).ConfigureAwait(false);
        var Books = await _booksDbContext.Books.ToArrayAsync(cancellationToken);
        //throw new NotImplementedException();
        return Books.Adapt<GetBooksResponse>();
    }
}
