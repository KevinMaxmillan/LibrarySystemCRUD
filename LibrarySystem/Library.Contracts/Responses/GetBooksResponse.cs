using LibrarySystem.Library.Contracts.Dtos;

namespace LibrarySystem.Library.Contracts.Responses;

public record GetBooksResponse(List<BookDto> BooksDtos);
{

}
