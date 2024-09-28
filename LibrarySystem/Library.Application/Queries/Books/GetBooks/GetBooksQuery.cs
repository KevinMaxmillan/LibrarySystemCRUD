using LibrarySystem.Library.Contracts.Responses;
using MediatR;

namespace LibrarySystem.Library.Application.Queries.Books.GetBooks;

// Query for retrieving a list of books
public record GetBooksQuery() : IRequest<GetBooksResponse>;

