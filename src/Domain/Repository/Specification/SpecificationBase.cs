using System.Linq.Expressions;
using Repository.Specification.And;
using Repository.Specification.Equal;
using Repository.Specification.Not;
using Repository.Specification.Or;

namespace Repository.Specification;

public abstract class SpecificationBase<T> : ISpecificationBase<T>
{
    public abstract Expression<Func<T, bool>> ToExpression();
    public virtual bool IsSatisfiedBy(T obj)
    {
        return ToExpression().Compile()(obj);
    }
    public static implicit operator Expression<Func<T, bool>>(SpecificationBase<T> specificationBase)
    {
        return specificationBase.ToExpression();
    }

    public SpecificationBase<T> And(SpecificationBase<T> specification)
        => new AndSpecification<T>(this, specification);
    public SpecificationBase<T> Or(SpecificationBase<T> specification)
        => new OrSpecification<T>(this, specification);
    public SpecificationBase<T> NotEqual(SpecificationBase<T> specification)
        => new NotEqualSpecification<T>(this, specification);
    public SpecificationBase<T> Equal(SpecificationBase<T> specification)
        => new EqualSpecification<T>(this, specification);
}