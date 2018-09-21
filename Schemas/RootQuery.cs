
using GraphQL.Types;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Services;
using Data;
using Entities;
using GraphQL.Language.AST;

namespace Schemas
{
    public class GeneralScalarGraphType : ScalarGraphType
    {
        public GeneralScalarGraphType()
        {
            this.Name = "Obj";
        }

        public override object Serialize(object value)
        {
            return this.ParseValue(value);
        }

        public override object ParseValue(object value)
        {
            if (value == null)
                return (object)null;
            int result1;
            if (int.TryParse(value.ToString(), out result1))
                return (object)result1;
            long result2;
            if (long.TryParse(value.ToString(), out result2))
                return (object)result2;
            return (object)value;
        }

        public override object ParseLiteral(IValue value)
        {
            IntValue intValue;
            LongValue longValue;
            if ((intValue = value as IntValue) != null)
                return (object)intValue.Value;
            if ((longValue = value as LongValue) != null)
                return (object)longValue.Value;

            return value.Value;
        }
    }
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
            Field(t => t.CreatedOn);
        }
    }

    public class ApplicationDataType : ObjectGraphType<ApplicationData>
    {
        public ApplicationDataType()
        {
            Field(t => t.ApplicationDisplay).Description("The business ID");
            Field(t => t.ApplicationStatus).Description("The category");
            Field(t => t.FirstName).Description("The total");
            Field(t => t.LastName).Description("The message");
            Field(t => t.Sin).Description("The percentage");
        }
    }



    public class InputSortDescriptorType : InputObjectGraphType<SortDescriptor>
    {
        public InputSortDescriptorType()
        {
            Field(t => t.Field, nullable: true);
            Field(t => t.Dir, nullable: true);
        }
       
    }

    public class InputGroupDescriptorType : InputObjectGraphType<GroupDescriptor>
    {
        public InputGroupDescriptorType()
        {
            Field(t => t.Field, nullable: true);
            Field(t => t.Dir, nullable: true);
        }

    }


    public class InputFilterDescriptorType : InputObjectGraphType<FilterDescriptor>
    {
        public InputFilterDescriptorType()
        {
            Field(t => t.Field);
            Field<EnumerationGraphType<FilterOperator>>("operator", resolve: ctx => ctx.Source.Operator);
            Field<GeneralScalarGraphType>("value", resolve: ctx => ctx.Source.Value);
        }
    }

    public class InputFilterStateType : InputObjectGraphType<FilterState>
    {
        public InputFilterStateType()
        {
            Field<EnumerationGraphType<FilterLogic>>("logic", resolve: ctx => ctx.Source.Logic);
            Field<ListGraphType<InputFilterDescriptorType>>("filters", resolve: ctx => ctx.Source.Filters);
        }
    }

    public class ByReviewPagedDataResultType : ObjectGraphType<PagedDataResult<ReviewView>>
    {
        public ByReviewPagedDataResultType()
        {
            Field<ListGraphType<ReviewViewType>>("data", resolve: ctx => ctx.Source.Data);
            Field(t => t.Total);
        }
    }

    public class ApplicationsPagedDataResultType : ObjectGraphType<PagedDataResult<ApplicationData>>
    {
        public ApplicationsPagedDataResultType()
        {
            Field<ListGraphType<ApplicationDataType>>("data", resolve: ctx => ctx.Source.Data);
            Field(t => t.Total);
        }
    }

    public class InputQueryStateType : InputObjectGraphType<QueryState>
    {
        public InputQueryStateType()
        {
            Field(t => t.Skip);
            Field(t => t.Take);
            Field<ListGraphType<InputGroupDescriptorType>>("group", resolve: ctx => ctx.Source.Group);
            Field<ListGraphType<InputSortDescriptorType>>("sort", resolve: ctx => ctx.Source.Sort);
            Field<InputFilterStateType>("filter", resolve: ctx => ctx.Source.Filter);

        }
    }


    public class RootQuery : ObjectGraphType
    {
        public RootQuery(ServiceLocator serviceLocator)
        {
            Field<ByReviewPagedDataResultType>("reviews",
                description: " The reviews",
                arguments: new QueryArguments(
                    new QueryArgument<InputQueryStateType>() {Name = "state"}
                ),
                resolve: ctx =>
                {
                    var queryState = ctx.GetArgument<QueryState>("state");

                    return ServiceLocator.Get<ReviewViewService>().GetReviews(queryState);
                });

            Field<ApplicationsPagedDataResultType>("applications",
                description: "The applications",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() {Name = "reviewBusinessId"},
                    new QueryArgument<InputQueryStateType>() { Name = "state" }
                ),
                resolve: ctx =>
                {
                    if (ctx.HasArgument("reviewBusinessId"))
                    {
                        var reviewBusinessId = ctx.GetArgument<string>("reviewBusinessId");
                        var queryState = ctx.GetArgument<QueryState>("state");

                        return ServiceLocator.Get<ReviewViewService>()
                            .GetApplicationsByReview(reviewBusinessId, queryState);
                    }

                    return new PagedDataResult<ApplicationData>()
                    {
                        Data = new ApplicationData[] { },
                        Total = 0
                    };
                });

        }
    }



}
