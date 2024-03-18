using System.Linq.Expressions;

namespace Repository.Specification
{
    public interface ISpecificationBase<T>
    {
        SpecificationBase<T> And(SpecificationBase<T> specification);
        SpecificationBase<T> Equal(SpecificationBase<T> specification);
        bool IsSatisfiedBy(T obj);
        SpecificationBase<T> NotEqual(SpecificationBase<T> specification);
        SpecificationBase<T> Or(SpecificationBase<T> specification);
        Expression<Func<T, bool>> ToExpression();
    }
}