using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Resolvers
{
    public interface IFieldResolver
    {
        QueryArguments GetArguments();

        object Resolve(ResolveFieldContext<object> context);


        IFieldType AddField(string name, ObjectGraphType graphType);
    }

    public interface IFieldResolver<Parent, Child>
    {
        QueryArguments GetArguments();

        Child Resolve(ResolveFieldContext<Parent> context);

        IFieldType AddField(string name, ObjectGraphType<Parent> graphType);
    }
}
