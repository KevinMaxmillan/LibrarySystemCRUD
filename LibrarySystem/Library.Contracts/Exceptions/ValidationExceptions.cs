namespace LibrarySystem.Library.Contracts.Exceptions;
using LibrarySystem.Library.Contracts.Errors;

public class ValidationExceptions : Exception
{
    public ValidationExceptions(List<ValidationErrors> validationErrors)
    {
        ValidationErrors = validationErrors;
    }

    public List<ValidationErrors> ValidationErrors { get; set; }
}
