using LibrarySystem.Library.Contracts.Responses;
using LibrarySystem.Library.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Library.Application.Queries.Books.GetBooksById;

public class GetBooksByIdQueryHandler : IRequestHandler<GetBooksByIdQuery, GetBooksByIdResponse>
{
    private readonly BooksDbContext _booksDbContext;
    public GetBooksByIdQueryHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }
    public async Task<GetBooksByIdResponse> Handle(GetBooksByIdQuery request, CancellationToken cancellationToken)
    {
        var Books = await _booksDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id
        ,cancellationToken);

        if (Books == null) 
        {
            throw new Exception();
        }


        
        return Books.Adapt<GetBooksByIdResponse>();
    }
}
