using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace InterfaceToolTest
{
    internal class ColumnExpressionVisitor : ExpressionVisitor
    {

        private Expression expression;
        private StringBuilder sb = new StringBuilder();

        public ColumnExpressionVisitor(Expression exp)
        {
            expression = exp;
        }

        public string GetColumnString()
        {
            Visit(expression);
            return sb.ToString().ToLower();
        }

        protected override Expression VisitMember(MemberExpression m)
        {
            var result = base.VisitMember(m);
            if (m.Member.DeclaringType == typeof(DateTime))
            {
                buildDateTimeFunction(m);
            }
            else if (m.Member.DeclaringType == typeof(string))
            {
                buildStringFunction(m);
            }
            else
            {
                bool isModel = false;
                //if (m.Member.MemberType == MemberTypes.Property)
                //{
                //    isModel = (m.Member as PropertyInfo).PropertyType.IsEntityOrValueObjectType();
                //}
                if (sb.Length <= 0 && !isModel)
                    sb.AppendFormat("{0}{1}{2}",
                        "[",
                        m.Expression.Type.Name,
                        "]");
                if (sb.Length > 0)
                    sb.Append('.');
                sb.AppendFormat("{0}{1}{2}",
                    "[",
                    m.Member.Name,
                   "]");
            }
            return result;
        }

        //protected override Expression VisitMemberAccess(MemberExpression m) {
        //    var result = base.VisitMemberAccess(m);
        //    if (m.Member.DeclaringType == typeof(DateTime)) {
        //        buildDateTimeFunction(m);
        //    } else if (m.Member.DeclaringType == typeof(string)) {
        //        buildStringFunction(m);
        //    } else {
        //        if (sb.Length <= 0)
        //            sb.AppendFormat("{0}{1}{2}", 
        //                DbEnviroumentFactory.Instanse.LeftTag, 
        //                m.Expression.Type.Name, 
        //                DbEnviroumentFactory.Instanse.RightTag);
        //        sb.AppendFormat(".{0}{1}{2}", 
        //            DbEnviroumentFactory.Instanse.LeftTag, 
        //            m.Member.Name, 
        //            DbEnviroumentFactory.Instanse.RightTag);
        //    }
        //    return result;
        //}

        private void buildDateTimeFunction(MemberExpression m)
        {
            if (m.Member.MemberType == MemberTypes.Property)
            {
                PropertyInfo property = m.Member as PropertyInfo;
                switch (property.Name)
                {
                    case "Day":
                        sb.Insert(0, "day(");
                        sb.Append(")");
                        break;
                    case "Month":
                        sb.Insert(0, "month(");
                        sb.Append(")");
                        break;
                    case "Year":
                        sb.Insert(0, "year(");
                        sb.Append(")");
                        break;
                    default:
                        break;
                }
            }
        }

        private void buildStringFunction(MemberExpression m)
        {
            if (m.Member.MemberType == MemberTypes.Property)
            {
                PropertyInfo propery = m.Member as PropertyInfo;
                switch (propery.Name)
                {
                    case "Length":
                        sb.Insert(0, "len(");
                        sb.Append(")");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
