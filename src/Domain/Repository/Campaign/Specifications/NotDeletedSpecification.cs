using System.Linq.Expressions;
using Database.Entities;
using Repository.Specification;

namespace Repository.Campaign.Specifications;

public class NotDeletedSpecification : SpecificationBase<CampaignEntity>
{
    public override Expression<Func<CampaignEntity, bool>> ToExpression()
    {
        return c => c.IsDeleted == false;
    }
}