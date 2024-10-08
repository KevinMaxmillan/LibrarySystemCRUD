﻿namespace LibrarySystem.Library.Application.Commands.Books.DeleteBook;
using FluentValidation;
using LibrarySystem.Library.Domain.Entities;

public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
{

    //validation to check if the book is there to delete
    public DeleteBookValidator()
    {
        RuleFor(x => x.Id).NotEmpty()
            .WithMessage($"{nameof(Book.Id)} cannot be empty");
    }
}
