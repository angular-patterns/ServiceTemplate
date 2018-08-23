using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Queries.RuleSets
{
    public class RuleSetQuery: GraphBase
    {
        public RuleSetQuery(DataContext context) : base(context)
        {

        }

        public IList<RuleSet> GetAll()
        {
            return Context.RuleSets.ToList();
        }

        public IList<RuleSet> GetByModelId(int modelId)
        {
            return Context.RuleSets.Where(t => t.ModelId == modelId).ToList();
        }

    }
}
