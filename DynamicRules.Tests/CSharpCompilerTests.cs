using DynamicRules.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel.DataAnnotations;
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
