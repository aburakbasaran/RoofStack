using Database.Entities;
using Repository.Specification;
using System.Linq.Expressions;

namespace Repository.Campaign.Specifications;

public class ActiveDateRangeSpecification : SpecificationBase<CampaignEntity>
{
    public override Expression<Func<CampaignEntity, bool>> ToExpression()
    {
        return c => c.StartDate <= DateTime.UtcNow &&
                    c.EndDate >= DateTime.UtcNow;
    }
}