using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Entities;

namespace Business.Services
{
    public class ReviewViewService: GraphBase
    {
        public ReviewViewService(DataContext dataContext): base (dataContext)
        {

        }
        public IList<ReviewView> GetAllReviews()
        {
            return this.Context.ReviewViews.ToList();
        }
    }
}
