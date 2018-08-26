using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Business.Services;
using Entities;
using GraphQL.Types;
using Schemas.Types;

namespace Schemas.Resolvers.ForContextItem
{
    public class ModelResolver : IFieldResolver<ContextItem, Model>
    {
        public ModelService ModelService
        {
            get
            {
                return ServiceLocator.ModelService;
            }
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
