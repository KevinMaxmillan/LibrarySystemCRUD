using MediatR;

namespace LibrarySystem.Library.Application.Commands.Books.DeleteBook;

//record class is used for ideal data transfer
public record DeleteBookCommand(int Id) : IRequest<Unit>;

