using LibrarySystem.Library.Contracts.Responses;
using MediatR;

namespace LibrarySystem.Library.Application.Queries.Books.GetBooksById;

public record GetBooksByIdQuery(int Id) : IRequest<GetBooksByIdResponse>;

