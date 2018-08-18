using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class GraphBase
    {
        protected DataContext Context { get; }
        public GraphBase(DataContext context)
        {
            Context = context;
        }
    }
}
