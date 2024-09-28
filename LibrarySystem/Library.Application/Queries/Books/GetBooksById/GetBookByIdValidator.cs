namespace LibrarySystem.Library.Application.Queries.Books.GetBooksById;
using FluentValidation;
using LibrarySystem.Library.Application.Commands.Books.DeleteBook;
using LibrarySystem.Library.Domain.Entities;



//validator for the retrieving the query by id
public class GetBookByIdValidator : AbstractValidator<GetBooksByIdQuery>
{
    public GetBookByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty()
            .WithMessage($"{nameof(Book.Id)} cannot be empty");
    }
}
