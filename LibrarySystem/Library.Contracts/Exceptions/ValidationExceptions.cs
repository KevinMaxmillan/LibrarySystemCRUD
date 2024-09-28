namespace LibrarySystem.Library.Contracts.Exceptions;
using LibrarySystem.Library.Contracts.Errors;

public class ValidationExceptions : Exception
{

    // Constructor
    public ValidationExceptions(List<ValidationErrors> validationErrors)
    {
        ValidationErrors = validationErrors;
    }


    //list of validation errors
    public List<ValidationErrors> ValidationErrors { get; set; }
}
