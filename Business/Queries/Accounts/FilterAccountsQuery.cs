using Data;

using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Queries.Accounts
{
    public class FilterAccountsQuery: GraphBase
    {
        public FilterAccountsQuery(DataContext context) : base(context)
        {

        }

        public IList<Account> FilterBy(FilterCriteria criteria)
        {
            criteria = criteria ?? new FilterCriteria();

            IQueryable<Account> queryable = Context.Accounts;
            if (criteria.Username != null)
                queryable = queryable.Where(t => t.Username == criteria.Username);

            if (criteria.Password != null)
                queryable = queryable.Where(t => t.Password == criteria.Password);

            return queryable.ToList();
        }

        public Account FindById(int id)
        {
            return Context.Accounts.Find(id);
        }

    }
}
