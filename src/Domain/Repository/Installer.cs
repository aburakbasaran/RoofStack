using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.Campaign;
using Repository.Common;

namespace Repository;

public static class Installer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICampaignRepo, CampaignRepo>();

        return services;
    }
}