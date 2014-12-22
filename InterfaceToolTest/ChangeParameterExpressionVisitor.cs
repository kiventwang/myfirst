using System.Linq.Expressions;

/// <summary>
/// Expression参数表达式转换器，将如果表达式中的参数表达式转换为提供的参数表达式
/// </summary>
public class ChangeParameterExpressionVisitor : ExpressionVisitor
{
    private ParameterExpression _parameterExpression;

    /// <summary>
    /// 转换表达式,替换表达式中的参数
    /// </summary>
    /// <param name="expression">原始表达式</param>
    /// <param name="parameter">新参数</param>
    /// <returns>转换后的表达式</returns>
    public Expression Convert(Expression expression, ParameterExpression parameter)
    {
        _parameterExpression = parameter;
        Expression result = Visit(expression);
        return result;
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        //return base.VisitParameter(node);
        base.VisitParameter(node);
        return _parameterExpression;
    }
}