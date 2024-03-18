using Database.Entities;
using Repository.Specification;
using Shared.DomainObject;

namespace Repository.Common;

public interface ICampaignRepo
{
    Task<List<GetCampaignDomainObject>> GetCampaignsAsync(ISpecificationBase<CampaignEntity> specification, CancellationToken cancellationToken);
    Task<bool> CreateAsync(CreateCampaignDomainObject request, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(UpdateCampaignDomainObject request, CancellationToken cancellationToken);
}