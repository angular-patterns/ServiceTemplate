using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Models
{
    /// <summary>
    /// https://stackoverflow.com/questions/40090303/use-sub-properties-in-expression-parameter-to-build-a-linq-expression
    /// https://stackoverflow.com/questions/15722880/build-expression-equals-on-string
    /// https://www.codeproject.com/Articles/1079028/Build-Lambda-Expressions-Dynamically
    /// 
    /// </summary>
    public class Expressions
    {
        public static Expression IsNull(ParameterExpression target, string field)
        {
            var memberAccess = CreateMemberAccess(target, field);
            var actualValue = Expression.Constant(null, memberAccess.Type);
            var expression = Expression.Equal(memberAccess, actualValue);
            return expression;
        }

        public static Expression IsNotNull(ParameterExpression target, string field)
        {
            return Expression.Not(IsNull(target, field));
        }


        public static Func<ParameterExpression, string, Expression> FromMethod(string method, object value)
        {
            bool not = false;
            if (method.StartsWith('!'))
            {
                not = true;
                method = method.Substring(1);
            }
            return (target, field) =>
            {
                var memberAccess = CreateMemberAccess(target, field);
                value = Convert.ChangeType(value, memberAccess.Type);
                var actualValue = Expression.Constant(value, memberAccess.Type);
                var methodInfo = memberAccess.Type.GetMethod(method, new[] { memberAccess.Type });
                Expression expr = Expression.Call(memberAccess, methodInfo, actualValue);
                if (not)
                    expr = Expression.Not(expr);

                return expr;
            };
        }


        public static Func<ParameterExpression, string, Expression> FromBinaryExpression(Func<Expression, Expression, BinaryExpression> binaryExpr, object value)
        {
            return (target, field) =>
            {
                bool not = false;
                if (field.StartsWith('!'))
                {
                    not = true;
                    field = field.Substring(1);
                }

               
                var memberAccess = CreateMemberAccess(target, field);
                value = Convert.ChangeType(value, memberAccess.Type);
                var actualValue = Expression.Constant(value, memberAccess.Type);


                Expression expr = binaryExpr(memberAccess, actualValue);
                if (not)
                    expr = Expression.Not(expr);

                return expr;
            };
        }

        public static Func<ParameterExpression, string, Expression> FromDateExpression(Func<Expression, Expression, BinaryExpression> binaryExpr, object value)
        {
            return (target, field) =>
            {
                bool not = false;
                if (field.StartsWith('!'))
                {
                    not = true;
                    field = field.Substring(1);
                }

                var dateValue = DateTime.ParseExact(value.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var memberAccess = CreateMemberAccess(target, field);
            
                var actualValue = Expression.Constant(dateValue, memberAccess.Type);
                var memberAccessDate = Expression.Property(memberAccess, "Date");
                var actualValueDate = Expression.Property(actualValue, "Date");


                Expression expr = binaryExpr(memberAccessDate, actualValueDate);
                if (not)
                    expr = Expression.Not(expr);

                return expr;
            };
        }

        static Expression CreateMemberAccess(Expression target, string selector)
        {
            return selector.Split('.').Aggregate(target, Expression.PropertyOrField);
        }

        //public static Expression<Func<T, bool>> Inverse<T>(this Expression<Func<T, bool>> e)
        //{
        //    return Expression.Lambda<Func<T, bool>>(Expression.Not(e.Body), e.Parameters[0]);
        //}


    }
}
