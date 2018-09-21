using Binbin.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;

namespace Models
{
    public static class PredicateExtensions
    {
        public static Expression<Func<T, bool>> ApplyFilter<T>(this Expression<Func<T, bool>> predicate, FilterLogic logic, FilterDescriptor filter) where T : class
        {

            switch (filter.Operator)
            {
                case FilterOperator.CONTAINS:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromMethod("Contains", filter.Value)));
                    break;
                case FilterOperator.DOESNOTCONTAIN:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromMethod("!Contains", filter.Value)));
                    break;
                case FilterOperator.EQ:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromMethod("Equals", filter.Value)));
                    break;
                case FilterOperator.NEQ:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromMethod("!Equals", filter.Value)));
                    break;
                case FilterOperator.ENDSWITH:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromMethod("EndsWith", filter.Value)));
                    break;
                case FilterOperator.STARTSWITH:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromMethod("StartsWith", filter.Value)));
                    break;
                case FilterOperator.ISEMPTY:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromMethod("Equals", string.Empty)));
                    break;
                case FilterOperator.ISNOTEMPTY:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromMethod("!Equals", string.Empty)));
                    break;
                case FilterOperator.ISNULL:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.IsNull));
                    break;
                case FilterOperator.ISNOTNULL:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.IsNotNull));
                    break;
                case FilterOperator.ISGREATERTHAN:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromBinaryExpression(Expression.GreaterThan, filter.Value)));
                    break;
                case FilterOperator.ISGREATERTHANOREQUALTO:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromDateExpression(Expression.GreaterThanOrEqual, filter.Value)));
                    break;
                case FilterOperator.ISLESSTHAN:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromBinaryExpression(Expression.LessThan, filter.Value)));
                    break;
                case FilterOperator.ISLESSTHANOREQUALTO:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromBinaryExpression(Expression.LessThanOrEqual, filter.Value)));
                    break;
                case FilterOperator.ISAFTER:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromDateExpression(Expression.GreaterThan, filter.Value)));
                    break;
                case FilterOperator.ISAFTEROREQUALTO:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromDateExpression(Expression.GreaterThanOrEqual, filter.Value)));
                    break;
                case FilterOperator.ISBEFORE:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromDateExpression(Expression.LessThan, filter.Value)));
                    break;
                case FilterOperator.ISBEFOREOREQUALTO:
                    predicate = predicate.FilterBy(logic, CreatePredicate<T>(filter.Field, Expressions.FromDateExpression(Expression.LessThanOrEqual, filter.Value)));
                    break;

            }

            return predicate;
        }

        public static Expression<Func<T, bool>> FilterBy<T>(this Expression<Func<T, bool>> t, FilterLogic logic, Expression<Func<T, bool>> other)
        {
            switch (logic)
            {
                case FilterLogic.And:
                    return t.And(other);
                case FilterLogic.Or:
                    return t.Or(other);
            }
            return t.And(other);
        }

        public static Expression<Func<T, bool>> Create<T>(FilterLogic logic)
        {
            switch (logic)
            {
                case FilterLogic.And:
                    return PredicateBuilder.True<T>();
                case FilterLogic.Or:
                    return PredicateBuilder.False<T>();
            }
            return PredicateBuilder.True<T>();
        }

        private static Expression<Func<T, bool>> CreatePredicate<T>(string field, Func<ParameterExpression, string, Expression> expr) where T : class
        {
            var target = Expression.Parameter(typeof(T));
            var expression = expr(target, field);
            var predicate = Expression.Lambda(expression, target);
            var typedExpression = (Expression<Func<T, bool>>)predicate;
            return typedExpression;
        }
        //private static Expression<Func<T, bool>> CreatePredicate<T>(Func<ParameterExpression, Expression> parameter)
        //{
        //    var target = Expression.Parameter(typeof(T));
        //    var expression = parameter(target);
        //    var predicate = Expression.Lambda(expression, target);
        //    var typedExpression = (Expression<Func<T, bool>>)predicate;
        //    return typedExpression;
        //}



    }
}
