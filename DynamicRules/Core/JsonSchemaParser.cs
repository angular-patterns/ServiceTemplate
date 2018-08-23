using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DynamicRules.Interfaces;


namespace DynamicRules.Core
{
    public class JsonSchemaParser : IJsonSchemaParser
    {
        public ICSharpCompiler Compiler { get; }
        public IJsonSchemaConverter Converter { get; }

        public JsonSchemaParser(ICSharpCompiler compiler, IJsonSchemaConverter converter)
        {
            this.Compiler = compiler;
            this.Converter = converter;
        }

        public async Task<JsonSchemaInfo> FromSchema(string jsonSchema, string typeName, string nameSpace)
        {
            var csharp = await this.Converter.JsonSchemaToCSharp(jsonSchema, nameSpace);
            var result = this.Compiler.Compile(csharp);
            if (!result.Success)
                throw new CompilerException("Failed to compile", result.Errors);

            var type = result.Assembly.GetType(nameSpace + "." + typeName);
            return new JsonSchemaInfo
            {
                TypeName = typeName,
                Namespace = nameSpace,
                Schema = jsonSchema,
                ModelType = type,
                ModelAssembly = result.Assembly
            };
        }

        public async Task<JsonSchemaInfo> FromCSharp(string csharpFile, string typeName)
        {
            var result = this.Compiler.Compile(csharpFile);
            if (!result.Success)
                throw new CompilerException("Failed to compile", result.Errors);

            var type = result.Assembly.GetType(typeName);
            var schema = await Converter.CSharpToJsonSchema(type);
            return new JsonSchemaInfo
            {
                TypeName = type.Name,
                Namespace = type.Namespace,
                Schema = schema,
                ModelType = type,
                ModelAssembly = result.Assembly
            };
        }
    }
}
