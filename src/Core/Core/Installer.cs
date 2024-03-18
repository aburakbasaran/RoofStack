using Core.Auth;
using Core.Cqs.Behavior;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class Installer
{
    public static IServiceCollection AddCqs(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddScoped<IUserManager, UserManager>();
        return services;
    }
}