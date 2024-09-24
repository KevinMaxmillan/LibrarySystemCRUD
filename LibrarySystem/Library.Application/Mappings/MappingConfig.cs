using LibrarySystem.Library.Contracts.Responses;
using LibrarySystem.Library.Domain.Entities;
using Mapster;

namespace LibrarySystem.Library.Application.Mappings;

public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<List<Book>, GetBooksResponse>.NewConfig()
            .Map(dest => dest.BooksDtos, src => src);
    }
}
