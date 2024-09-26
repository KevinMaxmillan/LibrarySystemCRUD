using MediatR;

namespace LibrarySystem.Library.Application.Commands.Books.CreateBook;

public record CreateBookCommand(string Title, string Author, string Description) : IRequest<int>;

