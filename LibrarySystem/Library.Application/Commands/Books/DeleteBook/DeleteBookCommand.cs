using MediatR;

namespace LibrarySystem.Library.Application.Commands.Books.DeleteBook;

public record DeleteBookCommand(int Id) : IRequest<Unit>;

