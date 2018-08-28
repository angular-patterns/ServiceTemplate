using Business.Mutations.Models;
using Business.Queries;
using DynamicRules.Common;
using DynamicRules.Common.Compilation;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ModelService
    {
        public IJsonSchemaParser JsonSchemaParser { get; }
        public CreateModelMutation CreateModelMutation { get; }
        public ModelQuery ModelQuery { get; }

        public ModelService(CreateModelMutation createModelMutation, ModelQuery modelQuery, IJsonSchemaParser jsonSchemaParser)
        {
            CreateModelMutation = createModelMutation;
            JsonSchemaParser = jsonSchemaParser;
            ModelQuery = modelQuery;
        }

        public async Task<Model> AddModelFromJsonSchema(int accountId, string jsonSchema, string typeName, string nameSpace)
        {
            var schemaInfo = await JsonSchemaParser.FromSchema(jsonSchema, typeName, nameSpace);
            var model = new Model
            {
                AccountId = accountId,
                JsonSchema = schemaInfo.Schema,
                CSharpSource = schemaInfo.CSharpSource,
                Namespace = schemaInfo.Namespace,
                TypeName = schemaInfo.TypeName
            };
            model.Source = "JsonSchema";
            return CreateModelMutation.Create(model);
        }

        public async Task<Model> AddModelFromCSharpSource(int accountId, string csharpSource, string typeName)
        {
            var schemaInfo = await JsonSchemaParser.FromCSharp(csharpSource, typeName);
            var model = new Model
            {
                AccountId = accountId,
                JsonSchema = schemaInfo.Schema,
                CSharpSource = schemaInfo.CSharpSource,
                Namespace = schemaInfo.Namespace,
                TypeName = schemaInfo.TypeName
            };
            model.Source = "CSharpSource";
            return CreateModelMutation.Create(model);

        }

        public CompilerResult Compile(string source)
        {
            var compiler = ServiceLocator.Instance.GetService<ICSharpCompiler>();
            
            return compiler.Compile(source);
        }

        public ModelValidationResult ValidateModel(string source, string typename)
        {
            var compiler = ServiceLocator.Instance.GetService<ICSharpCompiler>();
            var result = compiler.Compile(source);
            var validationResult = new ModelValidationResult()
            {
                Success = false,
                TypeFound = false, 
                CompileSucceeded = result.Success,
                CompileErrors = result.Errors
            };

            if (result.Success && !String.IsNullOrEmpty(typename))
            {
                validationResult.ModelType = result.Assembly.GetType(typename);
                validationResult.TypeFound = validationResult.ModelType != null;
            }

            validationResult.Success = result.Success && validationResult.TypeFound;
            return validationResult;

        }


        public Model GetById(int  modelId)
        {
            return ModelQuery.GetById(modelId);
        }

        public IList<Model> GetAll()
        {
            return ModelQuery.GetAll();
        }
    }
}
