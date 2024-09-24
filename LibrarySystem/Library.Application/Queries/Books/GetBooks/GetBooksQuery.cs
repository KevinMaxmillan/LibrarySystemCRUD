using LibrarySystem.Library.Contracts.Responses;
using MediatR;

namespace LibrarySystem.Library.Application.Queries.Books.GetBooks;

public record GetBooksQuery() : IRequest<GetBooksResponse>
{
}
