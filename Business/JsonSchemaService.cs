using DynamicRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class JsonSchemaService
    {
        public IJsonSchemaParser SchemaParser { get; }
        public ModelService ModelService { get; }

        public JsonSchemaService(IJsonSchemaParser schemaParser, ModelService modelService)
        {
            SchemaParser = schemaParser;
            ModelService = modelService;
        }

        public JsonSchemaInfo GetSchemaInfo(int modelId)
        {
            var model = ModelService.GetById(modelId);
            JsonSchemaInfo schemaInfo = null;
            if (model.Source == "CSharpSource")
            {
                schemaInfo = SchemaParser.FromCSharp(model.CSharpSource, model.Namespace + "." + model.TypeName).Result;
            }
            else if (model.Source == "JsonSchema")
            {
                schemaInfo = SchemaParser.FromSchema(model.JsonSchema, model.TypeName, model.Namespace).Result;
            }
            return schemaInfo;

        }

    }
}
