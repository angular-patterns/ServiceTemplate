using System;
using System.Collections.Generic;
using System.Text;
using Business;
using Entities;
using GraphQL.Types;

namespace Schemas.Resolvers.ForRoot
{
    public class ModelsResolver : IFieldResolver
    {
        public ModelService ModelService { get; }
        public ModelsResolver(ModelService modelService)
        {
            ModelService = modelService;
        }

        public QueryArguments GetArguments() {
            return new QueryArguments(new QueryArgument<IntGraphType>() { Name = "id" });
        }
        public object Resolve(ResolveFieldContext<object> ctx)
        {
            if (ctx.HasArgument("id"))
            {
                var modelId = ctx.GetArgument<int>("id");
                var model = ModelService.GetById(modelId);
                return new List<Model>() { model };
            }
            else
            {
                var models = ModelService.GetAll();
                return models;
            }

        }

        public IFieldType AddField(string name, ObjectGraphType graphType)
        {
            return graphType.Field<ListGraphType<ModelType>>(
                name: name,
                arguments: GetArguments(),
                resolve: Resolve);

        }


    }
}
