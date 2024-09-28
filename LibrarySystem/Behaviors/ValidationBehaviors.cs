namespace LibrarySystem.Behaviors;
using FluentValidation;
using FluentValidation.Validators;
using MediatR;
using LibrarySystem.Library.Contracts.Errors;
using LibrarySystem.Library.Contracts.Exceptions;


public class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>

{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviors(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
      CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(x => x.ValidateAsync(context, cancellationToken)));

        var failures = validationResults.Where(x => !x.IsValid)
            .SelectMany(x => x.Errors)
            .Select(x => new ValidationErrors
            {
                Property = x.PropertyName,
                ErrorMessage = x.ErrorMessage
            }).ToList();

        if (failures.Any())
        {
            throw new ValidationExceptions(failures);
        }

        var response = await next();
        return response;
    }
}
