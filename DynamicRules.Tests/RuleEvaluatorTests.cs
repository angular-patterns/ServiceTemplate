using DynamicRules.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic;
using System.Text;

namespace DynamicRules.Tests
{
    [TestClass]
    public class RuleEvaluatorTests
    {
        public class SampleClass
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }
        }

        [TestMethod]
        public void TestRunPredicateShouldReturnTrue()
        {
            var value = new SampleClass()
            {
                FirstName = "John",
                LastName = "Smith"
            };
            var ruleEvaluator = new RuleEvaluator();
            var result = ruleEvaluator.RunPredicate(typeof(SampleClass), value, "SampleClass.FirstName ==\"John\"");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestRunPredicateShouldReturnFalse()
        {
            var value = new SampleClass()
            {
                FirstName = "John",
                LastName = "Smith"
            };
            var ruleEvaluator = new RuleEvaluator();
            var result = ruleEvaluator.RunPredicate(typeof(SampleClass), value, "SampleClass.FirstName == null");
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ParseException))]
        public void TestRunPredicateShouldThrowException()
        {
            var value = new SampleClass()
            {
                FirstName = "John",
                LastName = "Smith"
            };
            var ruleEvaluator = new RuleEvaluator();
            ruleEvaluator.RunPredicate(typeof(SampleClass), value, "SampleClass.Blah == null");
        }


    }
}
