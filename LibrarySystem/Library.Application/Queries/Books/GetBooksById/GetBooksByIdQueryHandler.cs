using LibrarySystem.Library.Contracts.Exceptions;
using LibrarySystem.Library.Contracts.Responses;
using LibrarySystem.Library.Domain.Entities;
using LibrarySystem.Library.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Library.Application.Queries.Books.GetBooksById;

public class GetBooksByIdQueryHandler : IRequestHandler<GetBooksByIdQuery, GetBooksByIdResponse>
{
    private readonly BooksDbContext _booksDbContext;

    // Constructor
    public GetBooksByIdQueryHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }

    // Handles the Query and retrieves the book with the specific Id
    public async Task<GetBooksByIdResponse> Handle(GetBooksByIdQuery request, CancellationToken cancellationToken)
    {
        var Books = await _booksDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id
        ,cancellationToken);

        if (Books == null) 
        {
            throw new NotFoundExceptions($"{nameof(Book)} with {nameof(Book.Id)}: {request.Id}" + $"was not found in the Library");
        }


        // Map the retrieved book entity to the GetBooksByIdResponse using Mapster
        return Books.Adapt<GetBooksByIdResponse>();
    }
}
