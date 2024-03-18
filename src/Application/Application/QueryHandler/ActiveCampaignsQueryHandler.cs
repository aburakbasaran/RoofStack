using Application.Messages.Dto;
using Application.Messages.Query;
using Core.Cqs;
using Domain.Common;

namespace Application.QueryHandler;

internal class ActiveCampaignsQueryHandler(ICampaignService campaignService)
    : IQueryHandler<ActiveCampaignsQuery, IEnumerable<ActiveCampaignsResponseDto>>
{
    public async Task<IEnumerable<ActiveCampaignsResponseDto>> Handle(ActiveCampaignsQuery request, CancellationToken cancellationToken)
    {
        var campaignDo = await campaignService.GetActiveCampaignsAsync(cancellationToken);

        return campaignDo.Select(x => new ActiveCampaignsResponseDto(x.Id, x.Title, x.Description)).ToList();
    }
}