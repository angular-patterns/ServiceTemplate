using System;

using System.Linq;
using System.Linq.Expressions;

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
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> list, QueryState state)
        {
            IOrderedQueryable<T> orderedQueryable = null;

            foreach (var sort in state.Sort)
            {
                if (sort.Dir == null)
                    continue;

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

            return orderedQueryable ?? list;
        }



        public static IQueryable<T> ApplyFilter<T>(this IQueryable<T> list, QueryState state) where T: class
        {
            if (state.Filter != null)
            {
                var predicate = PredicateExtensions.Create<T>(state.Filter.Logic);
                foreach (var filter in state.Filter.Filters)
                {
                    predicate = predicate.ApplyFilter(state.Filter.Logic, filter);
                }
                list = list.Where(predicate);
            }
            return list;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> list, QueryState state)
        {
            return list.Skip(state.Skip).Take(state.Take);
        }

        public static PagedDataResult<T> Apply<T>(this IQueryable<T> list, QueryState state) where T: class
        {
            var sortAndFilter = list
                .ApplySorting(state)
                .ApplyFilter(state);
            return sortAndFilter.ApplyPaging(state).ToPagedResult(sortAndFilter.Count());
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



    }
}
