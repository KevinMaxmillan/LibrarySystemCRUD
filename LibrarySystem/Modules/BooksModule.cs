using LibrarySystem.Library.Application.Commands.Books.CreateBook;
using LibrarySystem.Library.Application.Commands.Books.DeleteBook;
using LibrarySystem.Library.Application.Commands.Books.UpdateBook;
using LibrarySystem.Library.Application.Queries.Books.GetBooks;
using LibrarySystem.Library.Application.Queries.Books.GetBooksById;
using LibrarySystem.Library.Contracts.Requests;
using MediatR;

namespace LibrarySystem.Modules;

public static class BooksModule
{
    public static void AddBookEndpoints(this IEndpointRouteBuilder app) 
    {
        app.MapGet("/api/books", async (IMediator mediator, CancellationToken ct) =>
        {
            var books = await mediator.Send(new GetBooksQuery(), ct);
            return Results.Ok(books);
        }).WithTags("Books");

        app.MapGet("/api/books/{Id}", async (IMediator mediator, int Id, CancellationToken ct) =>
        {
            var books = await mediator.Send(new GetBooksByIdQuery(Id));
            return Results.Ok(books);
        }).WithTags("Books");

        app.MapPost("/api/books", async (IMediator mediator,CreateBookRequest createBookrequest, CancellationToken ct) =>
        {
            var command = new CreateBookCommand(createBookrequest.Title, createBookrequest.Author, createBookrequest.Description); 
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Books");

        app.MapPut("/api/books/{Id}", async (IMediator mediator, int Id,UpdateBookRequest updateBookrequest, CancellationToken ct) =>
        {
            var command = new UpdateBookCommand(Id, updateBookrequest.Title, updateBookrequest.Author, updateBookrequest.Description);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Books");

        app.MapDelete("/api/books/{Id}", async (IMediator mediator, int Id, CancellationToken ct) =>
        {
            var command = new DeleteBookCommand(Id);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Books");
    }
}
