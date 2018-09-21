using GraphQL.Types;
using System;

namespace Web.Models
{
    public class NewAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Droid
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType()
        {
            Field(x => x.Id).Description("The Id of the Droid.");
            Field(x => x.Name, nullable: true).Description("The name of the Droid.");
        }
    }

    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery()
        {
            Field<DroidType>(
              "hero",
              resolve: context => new Droid { Id = 1, Name = "R2-D2" }
            );
        }
    }
}