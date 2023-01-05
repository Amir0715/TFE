using System.Reflection;
using System.Text;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TFE.Application.Behaviors;

namespace TFE.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        AddMapsterConfiguration(services);

        return services;
    }

    private static IServiceCollection AddMapsterConfiguration(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Default.IgnoreNullValues(true);
        var registers = config.Scan(AppDomain.CurrentDomain.GetAssemblies());
        var stringBuilder = new StringBuilder("Зарегистрированные конфигураторы мапстера:");
        foreach (var register in registers)
        {
            stringBuilder.AppendFormat("\n\t {0}", register.GetType());
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(stringBuilder.ToString());
        Console.ResetColor();

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}