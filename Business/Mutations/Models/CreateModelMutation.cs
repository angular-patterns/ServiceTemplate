using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mutations.Models
{
    public class CreateModelMutation: GraphBase
    {
        public CreateModelMutation(DataContext context) : base(context)
        {

        }

        public Model Create(Model model)
        {
            Context.Models.Add(model);
            Context.SaveChanges();
            return  model;
        }


    }
}
