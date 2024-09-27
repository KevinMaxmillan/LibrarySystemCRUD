namespace LibrarySystem.Library.Application.Queries.Books.GetBooksById;
using FluentValidation;
using LibrarySystem.Library.Application.Commands.Books.DeleteBook;
using LibrarySystem.Library.Domain.Entities;


public class GetBookByIdValidator : AbstractValidator<GetBooksByIdQuery>
{
    public GetBookByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty()
            .WithMessage($"{nameof(Book.Id)} cannot be empty");
    }
}
