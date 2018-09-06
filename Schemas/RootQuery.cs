
using GraphQL.Types;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Services;
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


    public class InputSortDescriptorType : InputObjectGraphType<SortDescriptor>
    {
        public InputSortDescriptorType()
        {
            Field(t => t.Field);
            Field(t => t.Dir);
        }
       
    }
    public class PagedDataResultType : ObjectGraphType<PagedDataResult<ReviewView>>
    {
        public PagedDataResultType()
        {
            Field<ListGraphType<ReviewViewType>>("data", resolve: ctx => ctx.Source.Data);
            Field(t => t.Total);
        }
    }
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(ServiceLocator serviceLocator)
        {
            Field<PagedDataResultType>("reviews",
                description:" The reviews",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name= "skip"},
                    new QueryArgument<IntGraphType>() { Name = "take" },
                    new QueryArgument<ListGraphType<InputSortDescriptorType>>() { Name = "sort" }
                ),
                resolve: ctx =>
                {
                    if (ctx.HasArgument("skip"))
                    {
                        var skip = ctx.GetArgument<int>("skip");
                        var take = ctx.GetArgument<int>("take");
                        var sort = ctx.GetArgument<SortDescriptor[]>("sort");

                        return ServiceLocator.Get<ReviewViewService>().GetReviews(skip, take, sort);
                    }

                    var data = ServiceLocator.Get<ReviewViewService>().GetAllReviews();

                    return new PagedDataResult<ReviewView>()
                    {
                        Data = data.ToArray(),
                        Total = data.Count
                    };
                });
        }

    }



}
