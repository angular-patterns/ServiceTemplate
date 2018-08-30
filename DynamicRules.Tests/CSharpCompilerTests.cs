using DynamicRules.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Reflection;

namespace DynamicRules.Tests
{
    [TestClass]
    public class CSharpCompilerTests
    {
        [TestMethod]
        public void ShouldCompileSimpleClass()
        {
            var subject = new CSharpCompiler();
            var result = subject.Compile(@"
                public class Person {
                    public string FirstName { get;set; }
                    public string LastName { get;set; }
                }
            ");

            Assert.IsTrue(result.Success);

            var type = GetTypeFromAssembly(result.Assembly, "Person");
            Assert.AreEqual("Person", type.Name);
            Assert.IsNull(type.Namespace);
            Assert.AreEqual(2, PropertyCount(type));
            Assert.IsTrue(HasProperty(type, "FirstName", typeof(string)));
            Assert.IsTrue(HasProperty(type, "LastName", typeof(string)));
        }

        [TestMethod]
        public void ShouldCompileWithRequiredField()
        {
            var subject = new CSharpCompiler();
            var result = subject.Compile(@"
                using System.ComponentModel.DataAnnotations;
                public class Person {
                    public string FirstName { get;set; }
                    [Required]
                    public string LastName { get;set; }
                }
            ");

            Assert.IsTrue(result.Success, result.ToString());

            var type = GetTypeFromAssembly(result.Assembly, "Person");
            Assert.AreEqual("Person", type.Name);
            Assert.IsNull(type.Namespace);
            Assert.IsTrue(HasAttribute(type, "LastName", typeof(RequiredAttribute)));

        }

        [TestMethod]
        public void ShouldCompileWithNamespace()
        {
            var subject = new CSharpCompiler();
            var result = subject.Compile(@"
                namespace Test {
                    public class Person {
                        public string FirstName { get;set; }
                        public string LastName { get;set; }
                    }
                }
            ");

            Assert.IsTrue(result.Success, result.ToString());

            var type = GetTypeFromAssembly(result.Assembly, "Test.Person");
            Assert.AreEqual("Person", type.Name);
            Assert.AreEqual("Test", type.Namespace);

        }

        [TestMethod]
        public void ShouldNotCompile()
        {
            var subject = new CSharpCompiler();
            var result = subject.Compile(@"
                namespace Test {
                    public class Person {
                        public blah FirstName { get;set; }
                        public string LastName { get;set; }
                    }
                }
            ");

            Assert.IsFalse(result.Success, result.ToString());
            Assert.IsNull(result.Assembly);


        }

        [TestMethod]
        public void ShouldSupportNestedTypes()
        {
            var subject = new CSharpCompiler();
            var result = subject.Compile(@"
                namespace Test {
                    public class Person {
                        public string FirstName { get;set; }
                        public string LastName { get;set; }
                        public Address Address { get;set; }
                    }

                    public class Address {
                        public string Street { get;set; }
                        public string City { get; set; }
                    }
                }
            ");
            Assert.IsTrue(result.Success, result.ToString());

            var personType = GetTypeFromAssembly(result.Assembly, "Test.Person");
            var addressType = GetTypeFromAssembly(result.Assembly, "Test.Address");
            Assert.AreEqual("Person", personType.Name);
            Assert.AreEqual("Test", personType.Namespace);
            Assert.IsTrue(HasProperty(personType, "Address", addressType));
        }

        [TestMethod]
        public void TestMaliciousFile()
        {
            var subject = new CSharpCompiler();
            var result = subject.Compile(@"
                public class Person {
                    public string Foo { 
                        get {
                            System.IO.File.WriteAllLines(""test.txt"", new string[] { ""test"" });

                            return ""bad"";
                        }
                    }
                }
            ");

            Assert.IsFalse(result.Success);

        }

  

        public const string PersonString = @"
using Newtonsoft.Json;
using System.ComponentModel;
namespace Test {
    public class Person
    {
        [DefaultValue(""Blue"")]
        public string FirstName { get; set; }
        [DefaultValue(""Blue"")]
        public string LastName { get; set; }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public Address Address { get; set; }
        public Person() {
            Address = new Address();
        }
    }
    public class Address
    {
        [DefaultValue(""Blue"")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string City { get; set; }
        [DefaultValue(""Blue"")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string Province { get; set; }
    }
}
";

        public class Person
        {
            [DefaultValue("")]
            public string FirstName { get; set; }
            [DefaultValue("")]
            public string LastName { get; set; }

            public Address Address { get; set; }
            public Person()
            {
                FirstName = "";
                LastName = "";
                Address = new Address();
            }
        }
        public class Address
        {
            [DefaultValue("")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
            public string City { get; set; }
            [DefaultValue("")]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
            public string Province { get; set; }
        }

        const string jsonSchema = @"
{
  ""$schema"": ""http://json-schema.org/draft-04/schema#"",
  ""title"": ""Person"",
  ""type"": ""object"",
  ""additionalProperties"": false,
  ""properties"": {
    ""FirstName"": {
      ""type"": [
        ""null"",
        ""string""
      ],
      ""default"": ""Blue""
    },
    ""LastName"": {
      ""type"": [
        ""null"",
        ""string""
      ],
      ""default"": ""Blue""
    },
    ""Address"": {
      ""oneOf"": [
        {
          ""type"": ""null""
        },
        {
          ""$ref"": ""#/definitions/Address""
        }
      ]
    }
  },
  ""definitions"": {
    ""Address"": {
      ""type"": ""object"",
      ""additionalProperties"": false,
      ""properties"": {
        ""City"": {
          ""type"": [
            ""null"",
            ""string""
          ],
          ""default"": ""Blue""
        },
        ""Province"": {
          ""type"": [
            ""null"",
            ""string""
          ],
          ""default"": ""Blue""
        }
      }
    }
  }
}
";

        [TestMethod]
        public void ShouldOutputModels()
        {
            var directory = Directory.GetCurrentDirectory();
            var person = File.ReadAllText("..\\..\\..\\models\\person.cs");
            var application = File.ReadAllText("..\\..\\..\\models\\application.cs");
            application = application.Replace("\r\n", "\\n").Replace("\"", "\\\"");
            Console.WriteLine(application);

            var createModel = @"
mutation CreateModel($accountId: Int!, $cSharpSource: String!, $typeName: String!) {
  createModel(fromCSharp: {accountId: $accountId, cSharpSource: $cSharpSource, typeName: $typeName}) {
    id
  }
}
varables {
    ""accountId"": {accountId},
    ""cSharpSource"": ""{cSharpSource}"",
    ""typeName"": ""{typeName}""  
}
";
            var accountId = 1;
            var typeName = "Test.Person";
            var cSharpSource = person.Replace("\r\n", "\\n").Replace("\"", "\\\"");
            var personModel = $"{createModel}"
                            .Replace("{accountId}", accountId.ToString())
                            .Replace("{cSharpSource}", cSharpSource)
                            .Replace("{typeName}", typeName);

            Console.WriteLine(personModel);

        }
        private bool HasAttribute(Type type, string propertyName, Type attributeType)
        {
            var attribute = type.GetProperty(propertyName).GetCustomAttribute(typeof(RequiredAttribute));
            return attribute != null;
        }

        private bool HasProperty(Type type, string propertyName, Type expectedType)
        {
            var property = type.GetProperty(propertyName);
            return property.PropertyType.Equals(expectedType);
        }

        private int PropertyCount(Type type)
        {
            return type.GetProperties().Length;
        }

        private Type GetTypeFromAssembly(Assembly assembly, string name)
        {
            return assembly.GetType(name, true);
        }
    }
}