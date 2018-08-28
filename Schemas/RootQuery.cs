using Business;
using GraphQL.Types;
using Schemas.Resolvers.ForRoot;
using Schemas.Types;

namespace Schemas
{
    public class RootQuery : ObjectGraphType
    {

        public RootQuery(ServiceLocator serviceLocator,
            ModelsResolver modelsResolver,
            RuleSetsResolver ruleSetsResolver,
            ReviewsResolver reviewsResolver,
            ContextsResolver contextsResolver,
            ReviewContextsResolver reviewContextsResolver)
        {

            modelsResolver.AddField("models", this);
            ruleSetsResolver.AddField("ruleSets", this);
            reviewsResolver.AddField("reviews", this);
            contextsResolver.AddField("contexts", this);
            reviewContextsResolver.AddField("reviewContexts", this);

            Field<CompilerResultType>(
                name: "compile",
                arguments: new QueryArguments(new QueryArgument<StringGraphType>() { Name = "source" }),
                resolve: ctx =>
                {
                    var source = ctx.GetArgument<string>("source");
                    return ServiceLocator.ModelService.Compile(source);
                });

            Field<ModelValidationResultType>(
                name: "validateModel",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType>() { Name = "source" },
                    new QueryArgument<StringGraphType>() { Name = "typename" }
                ),
                resolve: ctx =>
                {
                    var source = ctx.GetArgument<string>("source");
                    var typename = ctx.GetArgument<string>("typename");
                    return ServiceLocator.ModelService.ValidateModel(source, typename);
                });

        }

    }

}
