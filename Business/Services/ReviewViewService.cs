using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Binbin.Linq;
using Data;
using Entities;
using GraphQL;
using Microsoft.EntityFrameworkCore;
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

        public PagedDataResult<ReviewView> GetReviews(QueryState state)
        {
            return this.Context.ReviewViews
                .Apply(state)
                .ToPagedResult(this.Context.ReviewViews.Count());
        }

        public PagedDataResult<ApplicationData> GetApplicationsByReview(string reviewBusinessId, QueryState state)
        {
            var param = new SqlParameter("@ReviewBusinessId", reviewBusinessId);
            var queryable = Context.ApplicationDatas.FromSql("GetApplicationsByReview @ReviewBusinessId", param);
            return queryable
                .Apply(state)
                .ToPagedResult(queryable.Count());
        }
        
    }
}
