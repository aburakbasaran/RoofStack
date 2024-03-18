using System.Reflection;
using Application.Messages.Command;
using Application.Validation;
using Core;
using Database;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Application;

public static class Installer
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(CreateCampaignCommand).GetTypeInfo().Assembly);
        services.AddCqs(configuration);
        services.AddRepositories(configuration);
        services.AddDomainServices(configuration);
        services.InstallDatabase(configuration);

        services.AddTransient<IValidator<UpdateCampaignCommand>, UpdateCampaignValidator>();
        services.AddTransient<IValidator<CreateCampaignCommand>, CreateCampaignValidator>();

        return services;
    }
}