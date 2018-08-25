using Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Types
{
    public class ApplicationType: ObjectGraphType<Application>
    {
        public ApplicationType()
        {
            Field("id", t => t.ApplicationId, nullable: true).Description("field");
            Field(t => t.AccountId, nullable: true).Description("field");
            Field(t => t.BirthDate, nullable: true).Description("field");
            Field(t => t.City, nullable: true).Description("field");
            Field(t => t.Country, nullable: true).Description("field");
            Field(t => t.FirstName, nullable: true).Description("field");
            Field<GenderType>("gender", resolve: ctx => ctx.Source.Gender);
            Field(t => t.LastName, nullable: true).Description("field");
            Field(t => t.PostalCode, nullable: true).Description("field");
            Field(t => t.ProvinceState, nullable: true).Description("field");
            Field(t => t.Sin, nullable: true).Description("field");
            Field(t => t.Street, nullable: true).Description("field");
            Field(t => t.ApplicationDisplay, nullable: true).Description("field");

        }
    }

    public class GenderType: EnumerationGraphType<Gender>
    {
        public GenderType ()
        {
            Name = "Gender";
            AddValue("Male", string.Empty, 0);
            AddValue("Female", string.Empty, 1);
        }
    }
}
