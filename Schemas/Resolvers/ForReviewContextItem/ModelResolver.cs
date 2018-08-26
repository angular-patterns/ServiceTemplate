using Business;
using Business.Services;
using Entities;
using GraphQL.Types;
using Schemas.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schemas.Resolvers.ForReviewContextItem
{
    public class ModelResolver : IFieldResolver<ReviewContextItem, Model>
    {
        public ModelService ModelService = ServiceLocator.ModelService;

        public IFieldType AddField(string name, ObjectGraphType<ReviewContextItem> graphType)
        {
            return graphType.Field<ModelType>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);
        }

        public QueryArguments GetArguments()
        {
            return new QueryArguments();
        }

        public Model Resolve(ResolveFieldContext<ReviewContextItem> context)
        {
            return ModelService.GetById(context.Source.ModelId);
        }
    }
}
