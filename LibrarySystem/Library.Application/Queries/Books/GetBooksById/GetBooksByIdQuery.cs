using LibrarySystem.Library.Contracts.Responses;
using MediatR;

namespace LibrarySystem.Library.Application.Queries.Books.GetBooksById;

// Query for retrieving a book by its Id
public record GetBooksByIdQuery(int Id) : IRequest<GetBooksByIdResponse>;

