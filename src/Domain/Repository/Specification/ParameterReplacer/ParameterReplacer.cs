using System.Linq.Expressions;

namespace Repository.Specification.ParameterReplacer;

public class ParameterReplacer(ParameterExpression parameter) : ExpressionVisitor
{
    protected override Expression VisitParameter(ParameterExpression node)
        => base.VisitParameter(parameter);
}