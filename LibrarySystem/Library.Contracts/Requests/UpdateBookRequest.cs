namespace LibrarySystem.Library.Contracts.Requests;


//request for the updating a book
public record UpdateBookRequest(string Title, string Author, string Description);

