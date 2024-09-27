using System.Reflection;
using FluentValidation;
using LibrarySystem.Behaviors;
using LibrarySystem.Library.Application.Mappings;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
namespace LibrarySystem.Library.Application;

public static class DependancyInjection
{

    public static IServiceCollection AddAppication(this IServiceCollection services)
    {

        services.AddMediatR(cf =>
        {
            cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            cf.AddOpenBehavior(typeof(ValidationBehaviors<,>));
        
        });
        MappingConfig.Configure();
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());    

        return services;
    }
}
