
using GraphQL.Types;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Entities;

namespace Schemas
{
    public class ReviewViewType : ObjectGraphType<ReviewView>
    {
        public ReviewViewType()
        {
            Field(t => t.BusinessId).Description("The business ID");
            Field(t => t.Category).Description("The category");
            Field(t => t.Total).Description("The total");
            Field(t => t.Message).Description("The message");
            Field(t => t.Percentage).Description("The percentage");
            Field(t => t.RecordCount).Description("The record count");
            Field(t => t.SubCategory).Description("The sub-category");
        }
    }
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(DataContext context)
        {
            Field<ListGraphType<ReviewViewType>>("reviews",
                description:" The reviews",
                arguments: new QueryArguments(),
                resolve: ctx => context.ReviewViews.ToList());
        }

    }



}
