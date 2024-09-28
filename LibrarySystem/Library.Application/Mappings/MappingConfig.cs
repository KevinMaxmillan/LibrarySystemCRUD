using LibrarySystem.Library.Contracts.Responses;
using LibrarySystem.Library.Domain.Entities;
using Mapster;
using LibrarySystem.Library.Contracts.Dtos;

namespace LibrarySystem.Library.Application.Mappings;

public class MappingConfig
{
    public static void Configure()
    {
        // Configuration for mapping the list of Book entities to a GetBooksResponse
        TypeAdapterConfig<List<Book>, GetBooksResponse>.NewConfig()
             .Map(dest => dest.BooksDtos, src => src);

        // Configuration for mapping a single Book entity to a GetBooksByIdResponse
        TypeAdapterConfig<Book, GetBooksByIdResponse>.NewConfig()
             .Map(dest => dest.BooksDtos, src => src);
       
    }
}
