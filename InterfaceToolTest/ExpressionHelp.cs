using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Linq.Expressions;
using System.Windows.Forms.VisualStyles;

namespace InterfaceToolTest
{
    public class ExpressionHelp
    {
        private Expression<Func<UserInformation, bool>> ex = null;

        public void Builder(Expression<Func<UserInformation, bool>> expression)
        {
            var a = expression.Body;
            if (expression.Parameters.Count > 0)
            {
                var sqlString = "select * from {0}";
                var parameter = Expression.Parameter(typeof (UserInformation), "b");
                ChangeParameterExpressionVisitor changeParameterExpression = new ChangeParameterExpressionVisitor();
                var b =changeParameterExpression.Convert(a, parameter);
                WhereQuery query = new WhereQuery();
                WhereQuery<UserInformation> whereQuery = new WhereQuery<UserInformation>();
                whereQuery.And(expression);



            }
                 
        }

        


    }




    internal class WhereExpressionVisitor : ExpressionVisitor
    {
        private Expression expression;
        private WhereQuery query = new WhereQuery();

        public WhereExpressionVisitor(Expression exp)
        {
            expression = exp;
        }

        public WhereQuery GetQuery()
        {
            Visit(expression);
            return query;
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            parseCallItem(m);
            //return base.VisitMethodCall(m);
            return m;
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            if (b.NodeType == ExpressionType.And || b.NodeType == ExpressionType.AndAlso)
            {
                WhereExpressionVisitor leftVisitor = new WhereExpressionVisitor(b.Left);
                query.And(leftVisitor.GetQuery());
                WhereExpressionVisitor rightVisitor = new WhereExpressionVisitor(b.Right);
                query.And(rightVisitor.GetQuery());
            }
            else if (b.NodeType == ExpressionType.Or || b.NodeType == ExpressionType.OrElse)
            {
                WhereExpressionVisitor leftVisitor = new WhereExpressionVisitor(b.Left);
                query.Or(leftVisitor.GetQuery());
                WhereExpressionVisitor rightVisitor = new WhereExpressionVisitor(b.Right);
                query.Or(rightVisitor.GetQuery());
            }
            else
            {
                return visitWherePart(b);
            }
            return b;
        }

        private Expression visitWherePart(BinaryExpression b)
        {
            switch (b.NodeType)
            {
                default:
                    return base.VisitBinary(b);
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.Not:
                    parseWhereItem(b);
                    return b;
            }
        }

        private void parseCallItem(MethodCallExpression m)
        {
            if (m.Object.Type == typeof(string))
            {
                if (m.Method.Name == "Contains")
                {
                    var value = getValue(m.Arguments[0]);
                    ColumnExpressionVisitor columnVisitor = new ColumnExpressionVisitor(m.Object);
                    string parameterName = getParameter(m.Object as MemberExpression);
                    query = new WhereQuery();
                    query.Init(String.Format("{0} like {1}",
                        columnVisitor.GetColumnString(),
                        parameterName),
                        ParameterFactory.Create(parameterName, String.Format("%{0}%", value)));
                }
                else if (m.Method.Name == "StartsWith")
                {
                    var value = getValue(m.Arguments[0]);
                    ColumnExpressionVisitor columnVisitor = new ColumnExpressionVisitor(m.Object);
                    string parameterName = getParameter(m.Object as MemberExpression);
                    query = new WhereQuery();
                    query.Init(String.Format("{0} like {1}",
                        columnVisitor.GetColumnString(),
                        parameterName),
                        ParameterFactory.Create(parameterName, String.Format("{0}%", value)));
                }
                else if (m.Method.Name == "EndWith")
                {
                    var value = getValue(m.Arguments[0]);
                    ColumnExpressionVisitor columnVisitor = new ColumnExpressionVisitor(m.Object);
                    string parameterName = getParameter(m.Object as MemberExpression);
                    query = new WhereQuery();
                    query.Init(String.Format("{0} like {1}",
                        columnVisitor.GetColumnString(),
                        parameterName),
                        ParameterFactory.Create(parameterName, String.Format("%{0}", value)));
                }
            }
        }

        private object getValue(Expression exp)
        {
            ValueExpressionVisitor valueVisitor = new ValueExpressionVisitor(exp);
            return valueVisitor.GetValue();
        }

        private void parseWhereItem(BinaryExpression b)
        {
            ColumnExpressionVisitor columnVisitor = new ColumnExpressionVisitor(b.Left);
            ValueExpressionVisitor valueVisitor = new ValueExpressionVisitor(b.Right);
            query = new WhereQuery();
            string parameterName = getParameter(b.Left as MemberExpression);
            query.Init(String.Format("{0} {1} {2}",
                columnVisitor.GetColumnString(),
                getOperator(b),
                parameterName),
                ParameterFactory.Create(parameterName, valueVisitor.GetValue()));
          
        }

        private string getOperator(BinaryExpression b)
        {
            switch (b.NodeType)
            {
                default:
                    return String.Empty;
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                case ExpressionType.Equal:
                    return "=";
                case ExpressionType.NotEqual:
                    return "<>";
            }
        }

        private string getParameter(MemberExpression m)
        {
            return "@" + m.Member.Name.ToLower();
        }
    }


    public class WhereQuery 
    {
        protected StringBuilder sb = new StringBuilder();
        protected List<IDataParameter> parameterList = new List<IDataParameter>();

        public string QueryText
        {
            get
            {
                if (sb.Length <= 0)
                {
                    return "1 = 1";
                }
                return sb.ToString();
            }
        }

        public IDataParameter[] Parameters
        {
            get { return parameterList.ToArray(); }
        }

        internal WhereQuery()
        {
        }

        internal void Init(string text, params IDataParameter[] parameters)
        {
            if (sb.Length > 0)
                sb.Remove(0, sb.Length);
            parameterList.Clear();
            sb.Append(text);
            parameterList.AddRange(parameters);
        }

        internal void And(string text, params IDataParameter[] parameters)
        {
            if (sb.Length > 0)
                sb.AppendFormat(" {0} ","and");
            sb.Append(text);
            parameterList.AddRange(parameters);
        }

        internal void Or(string text, params IDataParameter[] parameters)
        {
            if (sb.Length > 0)
                sb.AppendFormat(" {0} ", "or");
            sb.Append(text);
            parameterList.AddRange(parameters);
        }

        internal void And(WhereQuery query)
        {
            if (sb.Length > 0)
                sb.AppendFormat(" {0} ", "and");
            sb.Append(query.QueryText);
            parameterList.AddRange(query.Parameters);
        }

        internal void Or(WhereQuery query)
        {
            if (sb.Length > 0)
                sb.AppendFormat(" {0} ", "or");
            sb.Append(query.QueryText);
            parameterList.AddRange(query.Parameters);
        }



    }

    public class WhereQuery<TEntity> : WhereQuery where TEntity : class 
    {
        public void And(Expression<Func<TEntity, bool>> selector)
        {
            WhereExpressionVisitor whereVisitor = new WhereExpressionVisitor(selector);
            And(whereVisitor.GetQuery());
        }

        public void Or(Expression<Func<TEntity, bool>> selector)
        {
            WhereExpressionVisitor whereVisitor = new WhereExpressionVisitor(selector);
            Or(whereVisitor.GetQuery());
        }

        public void Init(Expression<Func<TEntity, bool>> selector)
        {
            WhereExpressionVisitor whereVisitor = new WhereExpressionVisitor(selector);
            var query = whereVisitor.GetQuery();
            Init(query.QueryText, query.Parameters);
        }
    }

    internal static class ParameterFactory
    {
        private static readonly DbProviderFactory factory
            = SqlClientFactory.Instance;

        public static IDataParameter Create(string name)
        {
            return Create(name, null, null, null);
        }

        public static IDataParameter Create(string name, object value)
        {
            return Create(name, null, null, value);
        }

        public static IDataParameter Create(string name, DbType type, object value)
        {
            return Create(name, type, null, value);
        }

        public static IDataParameter Create(string name, DbType? type, int? size, object value)
        {
            var result = factory.CreateParameter();
            result.ParameterName = name;
            result.Value = value;
            if (type != null)
                result.DbType = type.Value;
            if (size != null)
                result.Size = size.Value;
            return result;
        }
    }
    
}
