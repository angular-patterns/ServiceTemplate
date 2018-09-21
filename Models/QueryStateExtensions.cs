using System;

using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Binbin.Linq;
using ExpressionBuilder.Common;
using ExpressionBuilder.Generics;
using GraphQL;

namespace Models
{
    public static class QueryStateExtensions
    {

        public static PagedDataResult<T> ToPagedResult<T>(this IQueryable<T> list, int count)
        {
            var subList = list.ToList();

            return new PagedDataResult<T>()
            {
                Data = subList.ToArray(),
                Total = count
            };
        }
        public static IOrderedQueryable<T> ApplySorting<T>(this IQueryable<T> list, QueryState state)
        {
            IOrderedQueryable<T> orderedQueryable = null;

            foreach (var sort in state.Sort)
            {
                if (orderedQueryable == null)
                    orderedQueryable = sort.Dir == "asc"
                        ? list.OrderBy(GetPropertySelector<T>(sort.Field))
                        : list.OrderByDescending(GetPropertySelector<T>(sort.Field));
                else
                {
                    orderedQueryable = sort.Dir == "asc"
                        ? orderedQueryable.ThenBy(GetPropertySelector<T>(sort.Field))
                        : orderedQueryable.ThenByDescending(GetPropertySelector<T>(sort.Field));
                }
            }

            return orderedQueryable;
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

        public static IQueryable<T> ApplySpecificFilter<T>(this IQueryable<T> list, FilterLogic logic, FilterDescriptor filter) where T: class
        {
            var predicate = PredicateBuilder.True<T>();
            
            switch (filter.Operator)
            {
                case FilterOperator.Contains:
                    predicate = predicate.FilterBy(logic, CreatePredicateExpression<T>(filter.Field, "Contains", filter.Value));
                    break;

                case FilterOperator.DoesNotContain:
                    predicate = predicate.FilterBy(logic, Inverse(CreatePredicateExpression<T>(filter.Field, "Contains", filter.Value)));
                    break;

                case FilterOperator.IsEqualTo:
                    predicate = predicate.FilterBy(logic, CreatePredicateExpression<T>(filter.Field, "Equals", filter.Value));
                    break;

                case FilterOperator.IsNotEqualTo:
                    predicate = predicate.FilterBy(logic, Inverse(CreatePredicateExpression<T>(filter.Field, "Equals", filter.Value)));
                    break;

                case FilterOperator.EndsWith:
                    predicate = predicate.FilterBy(logic, CreatePredicateExpression<T>(filter.Field, "EndsWith", filter.Value));
                    break;

                case FilterOperator.StartsWith:
                    predicate = predicate.FilterBy(logic, CreatePredicateExpression<T>(filter.Field, "StartsWith", filter.Value));
                    break;
                case FilterOperator.IsEmpty:
                    predicate = predicate.FilterBy(logic, CreatePredicateExpression<T>(filter.Field, "IsEmpty", filter.Value));
                    break;
                case FilterOperator.IsNotEmpty:
                    predicate = predicate.FilterBy(logic, Inverse(CreatePredicateExpression<T>(filter.Field, "IsEmpty", filter.Value)));
                    break;
                case FilterOperator.IsNull:
                    predicate = predicate.FilterBy(logic, CreatePredicateNullExpression<T>(filter.Field));
                    break;
                case FilterOperator.IsNotNull:
                    predicate = predicate.FilterBy(logic, Inverse(CreatePredicateNullExpression<T>(filter.Field)));
                    break;

            }



            list = list.Where(predicate);
            return list;
        }

        private static Expression<Func<T, bool>> CreatePredicateNullExpression<T>(string field)
        {
            var target = Expression.Parameter(typeof(T));
            var memberAccess = CreateMemberAccess(target, field);
            var actualValue = Expression.Constant(null, memberAccess.Type);

            var expression = Expression.Equal(memberAccess, actualValue);
            var predicate = Expression.Lambda(expression, target);
            var typedExpression = (Expression<Func<T, bool>>)predicate;
            return typedExpression;
        }

        private static Expression<Func<T, bool>> CreatePredicateExpression<T>(string field, string comparer, object value) where T: class
        {
            var target = Expression.Parameter(typeof(T));
            var expression = CreateComparison(target, field, comparer, value);
            var predicate = Expression.Lambda(expression, target);
            var typedExpression = (Expression<Func<T, bool>>)predicate;
            return typedExpression;
            //var filter = new Filter<T>();
            //filter.By(field, Operation.Contains, value);
            //Func<T, bool> tmp = filter;
            //return t=> tmp(t);
        }

      

        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> list, QueryState state) where T: class
        {
            if (state.Filter != null)
            {
                foreach (var filter in state.Filter.Filters)
                {
                    list = list.ApplySpecificFilter(state.Filter.Logic, filter);
                }
            }
            return list;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> list, QueryState state)
        {
            return list.Skip(state.Skip).Take(state.Take);
        }


        public static Expression<Func<T, object>> GetPropertySelector<T>(string propertyName)
        {
            var arg = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(arg, propertyName);
            //return the property as object
            var conv = Expression.Convert(property, typeof(object));
            var exp = Expression.Lambda<Func<T, object>>(conv, new ParameterExpression[] { arg });
            return exp;
        }

        //private static Expression<Func<T, bool>> GetPropertyPredicate<T, TProperty>(string field, Func<TProperty, bool> func)
        //{
        //    var arg = Expression.Parameter(typeof(T), "x");
        //    var property = Expression.Property(arg, field);
        //    //return the property as object
        //    var propertyExpr = Expression.Convert(property, typeof(TProperty));

        //    Expression<Func<TProperty, bool>> conv = p => func(p);
        //    var exp = Expression.Lambda<Func<T, bool>>(conv, new ParameterExpression[] { arg });
        //    return exp;
        //}

        /// <summary>
        /// https://stackoverflow.com/questions/40090303/use-sub-properties-in-expression-parameter-to-build-a-linq-expression
        /// https://stackoverflow.com/questions/15722880/build-expression-equals-on-string
        /// https://www.codeproject.com/Articles/1079028/Build-Lambda-Expressions-Dynamically
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="selector"></param>
        /// <param name="comparer"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IQueryable<T> Where<T>(this IQueryable<T> query, string selector, string comparer, object value)
        {
            var target = Expression.Parameter(typeof(T));

            return query.Provider.CreateQuery<T>(CreateWhereClause(target, query.Expression, selector, comparer, value));
        }

        static Expression CreateWhereClause(ParameterExpression target, Expression expression, string selector, string comparer, object value)
        {
            var predicate = Expression.Lambda(CreateComparison(target, selector, comparer, value), target);

            return Expression.Call(typeof(Queryable), nameof(Queryable.Where), new[] { target.Type },
                expression, Expression.Quote(predicate));
        }
        static Expression CreateComparison(ParameterExpression target, string selector, string comparer, object value)
        {
            var memberAccess = CreateMemberAccess(target, selector);
            var actualValue = Expression.Constant(value, memberAccess.Type);
            var methodInfo = memberAccess.Type.GetMethod(comparer, new[] { memberAccess.Type });
            
            return Expression.Call(memberAccess, methodInfo, actualValue);
        }

        //static Expression CreateDateComparison(ParameterExpression target, string selector, string comparer, object value)
        //{
           
        //    var memberAccess = CreateMemberAccess(target, selector);
        //    var actualValue = Expression.Constant(value, typeof(string));

        //    return Expression.GreaterThan(memberAccess, actualValue);

        //}

        static Expression CreateMemberAccess(Expression target, string selector)
        {
            return selector.Split('.').Aggregate(target, Expression.PropertyOrField);
        }
        public static Expression<Func<T, bool>> Inverse<T>(this Expression<Func<T, bool>> e)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.Not(e.Body), e.Parameters[0]);
        }
    }
}
