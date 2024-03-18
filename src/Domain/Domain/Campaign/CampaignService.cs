using Domain.Common;
using Repository.Campaign.Specifications;
using Repository.Common;
using Shared.DomainObject;

namespace Domain.Campaign;

public class CampaignService(ICampaignRepo campaignRepo) : ICampaignService
{
    public async Task<List<GetCampaignDomainObject>> GetActiveCampaignsAsync(CancellationToken cancellationToken)
    {
        var specification = new NotDeletedSpecification()
            .And(new ActiveDateRangeSpecification());

        return await campaignRepo.GetCampaignsAsync(specification, cancellationToken);
    }

    public async Task<bool> CreateAsync(CreateCampaignDomainObject request, CancellationToken cancellationToken)
    {
        return await campaignRepo.CreateAsync(request, cancellationToken);
    }

    public async Task<bool> UpdateAsync(UpdateCampaignDomainObject request, CancellationToken cancellationToken)
    {
        return await campaignRepo.UpdateAsync(request, cancellationToken);
    }
}