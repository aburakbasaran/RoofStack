using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Common;
using Repository.Specification;
using Shared.DomainObject;

namespace Repository.Campaign;

public class CampaignRepo(ICampaignDbContext context) : ICampaignRepo
{
    public async Task<List<GetCampaignDomainObject>> GetCampaignsAsync(ISpecificationBase<CampaignEntity> specification, CancellationToken cancellationToken)
    {
        return await context.Campaigns.Where(specification.ToExpression())
            .Select(x => new GetCampaignDomainObject(x.Id, x.Title, x.Description)).ToListAsync(cancellationToken);
    }

    public async Task<bool> CreateAsync(CreateCampaignDomainObject request, CancellationToken cancellationToken)
    {
        var campaignEntity =
            new CampaignEntity(request.Title, request.Description, request.StartDate.ToUniversalTime(), request.EndDate.ToUniversalTime(), false);

        await context.Campaigns.AddAsync(campaignEntity, cancellationToken);

        return await context.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task<bool> UpdateAsync(UpdateCampaignDomainObject request, CancellationToken cancellationToken)
    {
        var campaignEntity =
            await context.Campaigns.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

        if (campaignEntity is null)
        {
            return false;
        }

        campaignEntity.Update(request.Title,request.Description,request.StartDate,request.EndDate);

        context.Campaigns.Update(campaignEntity);

        return await context.SaveChangesAsync(cancellationToken) > 0;
    }
}