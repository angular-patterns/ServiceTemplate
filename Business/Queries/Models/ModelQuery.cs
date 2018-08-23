using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Queries
{
    public class ModelQuery: GraphBase
    {
        public ModelQuery(DataContext context) : base(context)
        {

        }

        public IList<Model> GetAll()
        {
            return Context.Models.ToList();
        }

        public Model GetById(int modelId)
        {
            return Context.Models.Find(modelId);
        }
    }
}
