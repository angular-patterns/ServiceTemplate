using DynamicRules.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJsonSchema.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicRules.Tests
{
    [TestClass]
    public class JsonValidatorTests
    {
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
        public void ShouldPassJsonValidationForEmptyJson()
        {
            var subject = new JsonValidator();
            var result = subject.Validate(SampleSchema, "{}").Result;
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void ShouldFailJsonValidationForInvalidType()
        {
            var subject = new JsonValidator();
            var result = subject.Validate(SampleSchema, "{ FirstName: 4}").Result;
            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Errors.Count, 1);
            Assert.AreEqual(result.Errors[0].Property, "FirstName");
            Assert.AreEqual(result.Errors[0].Kind, ValidationErrorKind.NoTypeValidates);

        }

        [TestMethod]
        public void ShoudlFailJsonValidationForAdditionalProperty()
        {
            var subject = new JsonValidator();
            var result = subject.Validate(SampleSchema, "{ MiddleName: \"test\"}").Result;
            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Errors.Count, 1);
            Assert.AreEqual(result.Errors[0].Property, "MiddleName");
            Assert.AreEqual(result.Errors[0].Kind, ValidationErrorKind.NoAdditionalPropertiesAllowed);

        }


        [TestMethod]
        public void ShoudlPassJsonValidation()
        {
            var subject = new JsonValidator();
            var result = subject.Validate(SampleSchema, "{ FirstName: \"test\", LastName: \"test\"}").Result;
            Assert.IsTrue(result.Success);

        }

    }
}
