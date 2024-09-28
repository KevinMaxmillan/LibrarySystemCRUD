using LibrarySystem.Library.Contracts.Dtos;

namespace LibrarySystem.Library.Contracts.Responses;

//response model to recieve a book by its id
public record GetBooksByIdResponse(BookDto BooksDtos);

