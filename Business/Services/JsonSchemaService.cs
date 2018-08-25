using Business.Services;
using DynamicRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class JsonSchemaService
    {
        public IJsonSchemaParser SchemaParser { get; }
        public ModelService ModelService { get { return ServiceLocator.ModelService; } }

        public JsonSchemaService(IJsonSchemaParser schemaParser)
        {
            SchemaParser = schemaParser;
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
