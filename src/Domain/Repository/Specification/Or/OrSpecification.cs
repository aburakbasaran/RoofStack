using System.Linq.Expressions;

namespace Repository.Specification.Or;

public class OrSpecification<T>(SpecificationBase<T> left, SpecificationBase<T> right) : SpecificationBase<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T, bool>> leftExpression = left.ToExpression();
        Expression<Func<T, bool>> rightExpression = right.ToExpression();

        ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
        BinaryExpression orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);
        orExpression = (BinaryExpression)new ParameterReplacer.ParameterReplacer(parameterExpression).Visit(orExpression);

        return Expression.Lambda<Func<T, bool>>(orExpression, parameterExpression);
    }
}