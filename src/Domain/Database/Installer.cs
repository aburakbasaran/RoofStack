using Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Database
{
    public static class Installer
    {
        public static IServiceCollection InstallDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CampaignDbContext>(
                db => db.UseNpgsql(configuration.GetConnectionString("PostgreConnectionString")));

            services.AddScoped<ICampaignDbContext, CampaignDbContext>();
            
            return services;
        }

    }
}
