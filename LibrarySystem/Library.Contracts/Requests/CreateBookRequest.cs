namespace LibrarySystem.Library.Contracts.Requests;


//request for the creating a new book
public record CreateBookRequest(string Title, string Author, string Description);

