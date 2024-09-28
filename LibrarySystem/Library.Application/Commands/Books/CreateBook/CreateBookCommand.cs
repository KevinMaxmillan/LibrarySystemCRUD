using MediatR;

namespace LibrarySystem.Library.Application.Commands.Books.CreateBook;


//record class is used for ideal data transfer
public record CreateBookCommand(string Title, string Author, string Description) : IRequest<int>;

