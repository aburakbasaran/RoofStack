using Application.Messages.Command;
using Core.Cqs;
using Domain.Common;
using Shared.DomainObject;

namespace Application.CommandHandler;

internal class UpdateCampaignCommandHandler(ICampaignService campaignService)
    : ICommandHandler<UpdateCampaignCommand, bool>
{
    public async Task<bool> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaignDo = new UpdateCampaignDomainObject(request.Id, request.Dto.Title,
            request.Dto.Description, request.Dto.StartDate, request.Dto.EndDate);

        return  await campaignService.UpdateAsync(campaignDo,cancellationToken);
    }
}