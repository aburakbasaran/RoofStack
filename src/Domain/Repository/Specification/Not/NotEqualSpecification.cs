using System.Linq.Expressions;

namespace Repository.Specification.Not;

public class NotEqualSpecification<T>(SpecificationBase<T> left, SpecificationBase<T> right) : SpecificationBase<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T, bool>> leftExpression = left.ToExpression();
        Expression<Func<T, bool>> rightExpression = right.ToExpression();

        ParameterExpression parameterExpression = Expression.Parameter(typeof(T));

        BinaryExpression notEqualExpression = Expression.NotEqual(leftExpression.Body, rightExpression.Body);
        notEqualExpression = (BinaryExpression)new ParameterReplacer.ParameterReplacer(parameterExpression).Visit(notEqualExpression);

        return Expression.Lambda<Func<T, bool>>(notEqualExpression, parameterExpression);
    }
}