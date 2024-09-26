using MediatR;

namespace LibrarySystem.Library.Application.Commands.Books.UpdateBook;

public record UpdateBookCommand(int Id, string Title, string Author, string Description) : IRequest<Unit>;

