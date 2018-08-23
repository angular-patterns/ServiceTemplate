using DynamicRules.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRules.Tests
{
    [TestClass]

    public class JsonSchemaConverterTests
    {
        public class SampleClass
        {
            public string FirstName { get; set; }
            
            public string LastName { get; set; }
        }
        public string SampleSchema = @"
{
  ""$schema"": ""http://json-schema.org/draft-04/schema#"",
  ""title"": ""SampleClass"",
  ""type"": ""object"",
  ""additionalProperties"": false,
  ""properties"": {
    ""FirstName"": {
      ""type"": [
        ""null"",
        ""string""
      ]
    },
    ""LastName"": {
      ""type"": [
        ""null"",
        ""string""
      ]
    }
  }
}
        ";
        [TestMethod]
        public void ShouldConvertToJsonSchema()
        {
            var converter = new JsonSchemaConverter();
            var schemaString = converter.CSharpToJsonSchema(typeof(SampleClass)).Result;
            var jsonSchema = JsonSchema4.FromTypeAsync<SampleClass>().Result.ToJson();
            Assert.IsNotNull(schemaString);
            Assert.AreEqual(jsonSchema, schemaString);
            
        }

        [TestMethod]
        public void ShouldParseJsonSchema()
        {
            var converter = new JsonSchemaConverter();
            var schemaString = converter.CSharpToJsonSchema(typeof(SampleClass)).Result;
            var jsonSchema = JsonSchema4.FromJsonAsync(schemaString);
            Assert.IsNotNull(schemaString);
            Assert.IsNotNull(jsonSchema);
        }

        [TestMethod]
        public void ShouldConvertToTypeAndCompile ()
        {
            var converter = new JsonSchemaConverter();
            var csharpClass = converter.JsonSchemaToCSharp(SampleSchema, "Test").Result;
            var result = new CSharpCompiler().Compile(csharpClass);
            Assert.IsNotNull(csharpClass);
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Assembly.GetType("Test.SampleClass"));

        }

        [TestMethod]
        public void ShouldConvertToTypeAndBackToSchema()
        {
            var converter = new JsonSchemaConverter();
            var csharpClass = converter.JsonSchemaToCSharp(SampleSchema, "Test").Result;
            var type = new CSharpCompiler().Compile(csharpClass).Assembly.GetType("Test.SampleClass");
            var schema = converter.CSharpToJsonSchema(type).Result;
            Assert.AreEqual(SampleSchema.Trim(), schema.Trim());
            
        }


    }


}
