using Domain.Campaign;
using Domain.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class Installer
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICampaignService, CampaignService>();

        return services;
    }
}