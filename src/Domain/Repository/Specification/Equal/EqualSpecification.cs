using System.Linq.Expressions;

namespace Repository.Specification.Equal;

public class EqualSpecification<T>(SpecificationBase<T> left, SpecificationBase<T> right) : SpecificationBase<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T, bool>> leftExpression = left.ToExpression();
        Expression<Func<T, bool>> rightExpression = right.ToExpression();

        ParameterExpression parameterExpression = Expression.Parameter(typeof(T));

        BinaryExpression equalExpression = Expression.Equal(leftExpression.Body, rightExpression.Body);
        equalExpression = (BinaryExpression)new ParameterReplacer.ParameterReplacer(parameterExpression).Visit(equalExpression);

        return Expression.Lambda<Func<T, bool>>(equalExpression, parameterExpression);
    }
}