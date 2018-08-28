using DynamicRules.Common;
using DynamicRules.Common.Compilation;
using DynamicRules.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class SampleClass
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
namespace DynamicRules.Tests
{

    [TestClass]
    public class JsonSchemaParserTests
    {
        public string SampleClassString = 
@"
public class SampleClass
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
}

";
        public string SampleSchemaString = @"
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
        public void TestFromSchema()
        {
            var compiler = Substitute.For<ICSharpCompiler>();
            var converter = Substitute.For<IJsonSchemaConverter>();
            var assembly = Substitute.For<Assembly>();

            var jsonToCSharpResult = Task.Run(() => SampleClassString);

            converter.JsonSchemaToCSharp(Arg.Is(SampleSchemaString), Arg.Is("Test")).Returns(jsonToCSharpResult);
            compiler.Compile(Arg.Is(SampleClassString)).Returns(new CompilerResult
            {
                Success = true,
                Errors = new List<CompilerError>(),
                Assembly = assembly
            });

            assembly.GetType(Arg.Is("Test.SampleClass"), Arg.Is(true)).Returns(typeof(Test.SampleClass));


            var subject = new JsonSchemaParser(compiler, converter);
           
            var schemaInfo = subject.FromSchema(SampleSchemaString, "SampleClass", "Test").Result;
            Assert.IsNotNull(schemaInfo);
            Assert.AreEqual("SampleClass", schemaInfo.TypeName);
            Assert.AreEqual("Test", schemaInfo.Namespace);
            Assert.AreEqual(SampleSchemaString, schemaInfo.Schema);
            Assert.AreEqual(typeof(Test.SampleClass), schemaInfo.ModelType);
            Assert.AreEqual(assembly, schemaInfo.ModelAssembly);

        }

        [TestMethod]
        public void TestFromCSharp()
        {
            var compiler = Substitute.For<ICSharpCompiler>();
            var converter = Substitute.For<IJsonSchemaConverter>();
            var assembly = Substitute.For<Assembly>();
            assembly.GetType(Arg.Is("Test.SampleClass"), Arg.Is(true)).Returns(typeof(Test.SampleClass));


            var csharpToJsonSchemaResult = Task.Run(() => SampleSchemaString);
            converter.CSharpToJsonSchema(Arg.Is(typeof(Test.SampleClass))).Returns(csharpToJsonSchemaResult);


            compiler.Compile(Arg.Is(SampleClassString)).Returns(new CompilerResult
            {
                Success = true,
                Errors = new List<CompilerError>(),
                Assembly = assembly
            });

            var subject = new JsonSchemaParser(compiler, converter);
            var schemaInfo = subject.FromCSharp(SampleClassString, "Test.SampleClass").Result;
            Assert.AreEqual("SampleClass", schemaInfo.TypeName);
            Assert.AreEqual("Test", schemaInfo.Namespace);
            Assert.AreEqual(SampleSchemaString, schemaInfo.Schema);
            Assert.AreEqual(typeof(Test.SampleClass), schemaInfo.ModelType);
            Assert.AreEqual(assembly, schemaInfo.ModelAssembly);

        }

        [TestMethod]        
        public void FromSchemaShouldThrowExceptionWhenCompileFails()
        {
            var compiler = Substitute.For<ICSharpCompiler>();
            var converter = Substitute.For<IJsonSchemaConverter>();
            var errors = new List<CompilerError>();


            var jsonToCSharpResult = Task.Run(() => SampleClassString);

            converter.JsonSchemaToCSharp(Arg.Is(SampleSchemaString), Arg.Is("Test")).Returns(jsonToCSharpResult);
            compiler.Compile(Arg.Is(SampleClassString)).Returns(new CompilerResult
            {
                Success = false,
                Errors = errors,
                Assembly = null
            });

            var subject = new JsonSchemaParser(compiler, converter);
            var exceptionTask = subject.FromSchema(SampleSchemaString, "SampleClass", "Test");
            try
            {
                var result = exceptionTask.Result;
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.GetType(), typeof(AggregateException));
                Assert.AreEqual(exception.InnerException.GetType(), typeof(CompilerException));
                Assert.AreEqual(((CompilerException)exception.InnerException).Errors, errors);
            }

        }

        [TestMethod]
        public void FromCSharpShouldThrowCompilerException()
        {
            var compiler = Substitute.For<ICSharpCompiler>();
            var converter = Substitute.For<IJsonSchemaConverter>();
            var errors = new List<CompilerError>();


            var csharpToJsonSchemaResult = Task.Run(() => SampleSchemaString);
            converter.CSharpToJsonSchema(Arg.Is(typeof(Test.SampleClass))).Returns(csharpToJsonSchemaResult);


            compiler.Compile(Arg.Is(SampleClassString)).Returns(new CompilerResult
            {
                Success = false,
                Errors = errors,
                Assembly = null
            });


            var subject = new JsonSchemaParser(compiler, converter);
            var exceptionTask = subject.FromCSharp(SampleClassString, "Test.SampleClass");
            try
            {
                var result = exceptionTask.Result;
            }
            catch (Exception exception)
            {
                Assert.AreEqual(exception.GetType(), typeof(AggregateException));
                Assert.AreEqual(exception.InnerException.GetType(), typeof(CompilerException));
                Assert.AreEqual(((CompilerException)exception.InnerException).Errors, errors);
            }


        }
    }
}
