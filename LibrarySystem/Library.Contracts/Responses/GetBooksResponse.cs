using LibrarySystem.Library.Contracts.Dtos;

namespace LibrarySystem.Library.Contracts.Responses;

//response model to recieve a book as a list of books
public record GetBooksResponse(List<BookDto> BooksDtos);

