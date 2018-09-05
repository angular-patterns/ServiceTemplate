using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Entities;
using GraphQL;
using Models;

namespace Business.Services
{
    public class ReviewViewService: GraphBase
    {
        public ReviewViewService(DataContext dataContext): base (dataContext)
        {

        }
        public IList<ReviewView> GetAllReviews()
        {
            var list = this.Context.ReviewViews.ToList();
            return list;
        }

        public PagedDataResult<ReviewView> GetReviews(int skip, int take, SortDescriptor[] sortFields)
        {
            var list = this.Context.ReviewViews;
            IOrderedQueryable<ReviewView> orderedQueryable = null;
            foreach (var sort in sortFields)
            {
                if (orderedQueryable == null)
                    orderedQueryable = sort.Dir == "asc"
                        ? list.OrderBy(t => t.GetPropertyValue(sort.Field))
                        : list.OrderByDescending(t => t.GetPropertyValue(sort.Field));
                else
                {
                    orderedQueryable = sort.Dir == "asc"
                        ? orderedQueryable.ThenBy(t => t.GetPropertyValue(sort.Field))
                        : orderedQueryable.ThenByDescending(t => t.GetPropertyValue(sort.Field));
                }
            }

            var subList = orderedQueryable != null
                ? orderedQueryable.Skip(skip).Take(take).ToList()
                : list.Skip(skip).Take(take).ToList();

            return new PagedDataResult<ReviewView>()
            {
                Data = subList.ToArray(),
                Total = list.Count()
            };
        }
    }
}
