// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.ObjectModel;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.TypeValidation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands.Parameters.ArgumentValidation.TypeValidation
{
    [TestFixture]
    public class IntTypeValidatorTests
    {
        private IntTypeValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new IntTypeValidator();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validate_NullArgumets_Throws()
        {
            _validator.Validate(null);
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("-10")]
        public void Validate_Succeeded_ReturnsTrue(string value)
        {
            var collection = new Collection<string>
                                 {
                                     value
                                 };

            var result = _validator.Validate(collection);

            Assert.IsTrue(result);
        }

        [TestCase("1")]
        [TestCase("2")]
        [TestCase("-10")]
        public void Validate_Succeeded_EmptyErrorMessage(string value)
        {
            var collection = new Collection<string>
                                 {
                                     value
                                 };

            _validator.Validate(collection);

            Assert.IsEmpty(_validator.ErrorMessage);
        }

        [TestCase("1.1")]
        [TestCase("2,1")]
        [TestCase("a")]
        [TestCase("-")]
        public void Validate_Fail_ReturnsFalse(string value)
        {
            var collection = new Collection<string>
                                 {
                                     value
                                 };

            var result = _validator.Validate(collection);

            Assert.IsFalse(result);
        }

        [TestCase("1.1")]
        [TestCase("2,1")]
        [TestCase("a")]
        [TestCase("-")]
        public void Validate_Fail_NotEmptyErrorMessage(string value)
        {
            var collection = new Collection<string>
                                 {
                                     value
                                 };

           _validator.Validate(collection);

            Assert.IsNotEmpty(_validator.ErrorMessage);
        }
    }
}
