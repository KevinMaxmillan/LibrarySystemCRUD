using MediatR;

namespace LibrarySystem.Library.Application.Commands.Books.UpdateBook;


//record class is used for ideal data transfer
public record UpdateBookCommand(int Id, string Title, string Author, string Description) : IRequest<Unit>;

