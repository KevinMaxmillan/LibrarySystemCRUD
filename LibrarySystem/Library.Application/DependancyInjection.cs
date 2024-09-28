using System.Reflection;
using FluentValidation;
using LibrarySystem.Behaviors;
using LibrarySystem.Library.Application.Mappings;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
namespace LibrarySystem.Library.Application;


// Static class for configuring dependency injection for the application
public static class DependancyInjection
{

    public static IServiceCollection AddAppication(this IServiceCollection services)
    {
        // Register MediatR services

        services.AddMediatR(cf =>
        {
            cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            cf.AddOpenBehavior(typeof(ValidationBehaviors<,>));
        
        });

        // Configure mapping settings
        MappingConfig.Configure();
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());    

        return services;
    }
}
