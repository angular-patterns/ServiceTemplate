using Business;
using GraphQL.Types;
using Schemas.Resolvers.ForRoot;


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
        }

    }

}
