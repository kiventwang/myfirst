using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace InterfaceToolTest
{
    internal class ValueExpressionVisitor : ExpressionVisitor
    {
        private Expression expression;
        private object value = null;

        public ValueExpressionVisitor(Expression exp)
        {
            expression = exp;
        }

        public object GetValue()
        {
            Visit(expression);
            return value;
        }

        private bool isContaint = true;

        protected override Expression VisitConstant(ConstantExpression c)
        {
            if (isContaint)
            {
                value = c.Value;
            }
            return base.VisitConstant(c);
        }

        protected override Expression VisitMember(MemberExpression m)
        {
            isContaint = false;
            if (m.Expression == null)
            {
                value = getValue(m, value);
                return base.VisitMember(m);
            }
            else if (m.Expression.NodeType == ExpressionType.Constant)
            {
                value = getValue(m, (m.Expression as ConstantExpression).Value);
                return m;
            }
            else
            {
                var result = base.VisitMember(m);
                value = getValue(m, value);
                return result;
            }
        }

        //protected override Expression VisitMemberAccess(MemberExpression m) {
        //    isContaint = false;
        //    if (m.Expression == null) {
        //        value = getValue(m, value);
        //        return base.VisitMemberAccess(m);
        //    } else if (m.Expression.NodeType == ExpressionType.Constant) {
        //        value = getValue(m, (m.Expression as ConstantExpression).Value);
        //        return m;
        //    } else {
        //        var result = base.VisitMemberAccess(m);
        //        value = getValue(m, value);
        //        return result;
        //    }
        //}

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            Visit(m.Object);
            IList<object> parameters = new List<object>();
            foreach (var item in m.Arguments)
            {
                ValueExpressionVisitor valueVisitor = new ValueExpressionVisitor(item);
                parameters.Add(valueVisitor.GetValue());
            }
            value = getMethodValue(m.Method, value, parameters.ToArray());
            return m;
        }

        private object getValue(MemberExpression m, object instanse)
        {
            object result = null;
            switch (m.Member.MemberType)
            {
                case MemberTypes.Field:
                    result = getFieldValue(m.Member as FieldInfo, instanse);
                    break;
                case MemberTypes.Method:
                    result = getMethodValue(m.Member as MethodInfo, instanse);
                    break;
                case MemberTypes.Property:
                    result = getPropertyValue(m.Member as PropertyInfo, instanse);
                    break;
                default:
                    break;
            }
            return result;
        }

        private object getFieldValue(FieldInfo fieldInfo, object instanse)
        {
            return fieldInfo.GetValue(instanse);
            //var fun = fieldInfo.GetFieldValueFunction();
            //return fun(instanse);
        }

        private object getMethodValue(MethodInfo methodInfo, object instanse, params object[] parameters)
        {
            return methodInfo.Invoke(instanse, parameters);
            //return methodInfo.GetFastInvoker()(instanse, parameters);
        }

        private object getPropertyValue(PropertyInfo propertyInfo, object instanse)
        {
            return propertyInfo.GetValue(instanse, null);
        }
    }
}
