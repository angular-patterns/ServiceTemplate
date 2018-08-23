using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DynamicRules.Interfaces;


namespace DynamicRules.Core
{
    public class JsonSchemaConverter: IJsonSchemaConverter
    {
        public async Task<string> JsonSchemaToCSharp(string schemaData, string ns)
        {
            var schema = await JsonSchema4.FromJsonAsync(schemaData);
            var generator = new CSharpGenerator(schema, new CSharpGeneratorSettings() { Namespace = ns });
            return generator.GenerateFile();
        }
        public async Task<string> CSharpToJsonSchema(Type type)
        {
            var schema = await JsonSchema4.FromTypeAsync(type);
            var schemaData = schema.ToJson();
            return schemaData;

        }
    }
}
