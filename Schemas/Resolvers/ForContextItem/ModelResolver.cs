using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Entities;
using GraphQL.Types;

namespace Schemas.Resolvers.ForContextItem
{
    public class ModelResolver : IFieldResolver<ContextItem, Model>
    {
        public ModelService ModelService { get; }
        public ModelResolver(ModelService modelService)
        {
            ModelService = modelService;
        }


        public IFieldType AddField(string name, ObjectGraphType<ContextItem> graphType)
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

        public Model Resolve(ResolveFieldContext<ContextItem> ctx)
        {
            var modelId = ctx.Source.ModelId;
            return ModelService.GetById(modelId);
        }

    }
}
