namespace LibrarySystem.Library.Application.Commands.Books.UpdateBook;
using FluentValidation;
using LibrarySystem.Library.Application.Commands.Books.CreateBook;
using LibrarySystem.Library.Domain.Entities;
public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookValidator()
    {

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Book.Id)} cannot be empty");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage($"{nameof(Book.Title)} cannot be empty")
            .MaximumLength(30)
            .WithMessage($"{nameof(Book.Title)} cannot be longer than 30 characters");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage($"{nameof(Book.Author)} cannot be empty")
            .MaximumLength(50)
            .WithMessage($"{nameof(Book.Author)} cannot be longer than 50 characters");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage($"{nameof(Book.Description)} cannot be empty")
            .MaximumLength(100)
            .WithMessage($"{nameof(Book.Description)} cannot be longer than 100 characters");
    }
}
