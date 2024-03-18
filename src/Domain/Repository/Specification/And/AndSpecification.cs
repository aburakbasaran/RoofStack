using System.Linq.Expressions;

namespace Repository.Specification.And;

public class AndSpecification<T>(SpecificationBase<T> left, SpecificationBase<T> right) : SpecificationBase<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T, bool>> leftExpression = left.ToExpression();
        Expression<Func<T, bool>> rightExpression = right.ToExpression();

        ParameterExpression parameterExpression = Expression.Parameter(typeof(T));
        BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
        andExpression = (BinaryExpression)new ParameterReplacer.ParameterReplacer(parameterExpression).Visit(andExpression);

        return Expression.Lambda<Func<T, bool>>(andExpression, parameterExpression);
    }
}