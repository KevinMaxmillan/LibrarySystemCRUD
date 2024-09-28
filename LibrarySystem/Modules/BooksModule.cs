using LibrarySystem.Library.Application.Commands.Books.CreateBook;
using LibrarySystem.Library.Application.Commands.Books.DeleteBook;
using LibrarySystem.Library.Application.Commands.Books.UpdateBook;
using LibrarySystem.Library.Application.Queries.Books.GetBooks;
using LibrarySystem.Library.Application.Queries.Books.GetBooksById;
using LibrarySystem.Library.Contracts.Requests;
using MediatR;

namespace LibrarySystem.Modules;


// Static class for defining API endpoints related to books
public static class BooksModule
{
    public static void AddBookEndpoints(this IEndpointRouteBuilder app) 
    {

        // Endpoint to get a list of all books
        app.MapGet("/api/books", async (IMediator mediator, CancellationToken ct) =>
        {
            var books = await mediator.Send(new GetBooksQuery(), ct);
            return Results.Ok(books);
        }).WithTags("Books");

        // Endpoint to get a specific book by Id

        app.MapGet("/api/books/{Id}", async (IMediator mediator, int Id, CancellationToken ct) =>
        {
            var books = await mediator.Send(new GetBooksByIdQuery(Id));
            return Results.Ok(books);
        }).WithTags("Books");


        // Endpoint to create a new book
        app.MapPost("/api/books", async (IMediator mediator,CreateBookRequest createBookrequest, CancellationToken ct) =>
        {
            var command = new CreateBookCommand(createBookrequest.Title, createBookrequest.Author, createBookrequest.Description); 
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Books");

        // Endpoint to update an existing book by Id
        app.MapPut("/api/books/{Id}", async (IMediator mediator, int Id,UpdateBookRequest updateBookrequest, CancellationToken ct) =>
        {
            var command = new UpdateBookCommand(Id, updateBookrequest.Title, updateBookrequest.Author, updateBookrequest.Description);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Books");

        // Endpoint to delete a book by Id
        app.MapDelete("/api/books/{Id}", async (IMediator mediator, int Id, CancellationToken ct) =>
        {
            var command = new DeleteBookCommand(Id);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Books");
    }
}
