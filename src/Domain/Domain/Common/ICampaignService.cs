using Shared.DomainObject;

namespace Domain.Common;

public interface ICampaignService
{
    Task<List<GetCampaignDomainObject>> GetActiveCampaignsAsync(CancellationToken cancellationToken);
    Task<bool> CreateAsync(CreateCampaignDomainObject request, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(UpdateCampaignDomainObject request, CancellationToken cancellationToken);
}