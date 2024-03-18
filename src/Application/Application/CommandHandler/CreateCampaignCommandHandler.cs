using Application.Messages.Command;
using Core.Cqs;
using Domain.Common;
using Shared.DomainObject;

namespace Application.CommandHandler;

internal class CreateCampaignCommandHandler(ICampaignService campaignService)
    : ICommandHandler<CreateCampaignCommand, bool>
{
    public async Task<bool> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaignDo = new CreateCampaignDomainObject( request.Dto.Title,
            request.Dto.Description, request.Dto.StartDate, request.Dto.EndDate);

        return  await campaignService.CreateAsync(campaignDo,cancellationToken);
    }
}