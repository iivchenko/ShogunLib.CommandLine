// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Globalization;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands.Parameters.ArgumentValidation
{
    public abstract class BaseValidatorTests
    {
        protected IArgumentValidator Validator { get; set; }

        [SetUp]
        public virtual void Setup()
        {
            SetupInternal();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validate_NullArguments_Throws()
        {
            Validator.Validate(null);
        }

        [Test, TestCaseSource("SuccessTestArgs")]
        public void Validate_Succeeded_ReturnsTrue(ValidationCollection args)
        {
            var isValid = Validator.Validate(args);

            Assert.IsTrue(isValid, string.Format(CultureInfo.InvariantCulture, "Input arguments: {0}", args));
        }

        [Test, TestCaseSource("SuccessTestArgs")]
        public void Validate_Succeeded_EmptyErrorMessage(ValidationCollection args)
        {
            Validator.Validate(args);

            Assert.IsEmpty(Validator.ErrorMessage, string.Format(CultureInfo.InvariantCulture, "Input arguments: {0}", args));
        }

        [Test, TestCaseSource("FailTestArgs")]
        public void Validate_Fail_ReturnsFalse(IEnumerable<string> args)
        {
            var isValid = Validator.Validate(args);

            Assert.IsFalse(isValid, string.Format(CultureInfo.InvariantCulture, "Input arguments: {0}", args));
        }

        [Test, TestCaseSource("FailTestArgs")]
        public void Validate_Fail_NotEmptyErrorMessage(IEnumerable<string> args)
        {
            Validator.Validate(args);

            Assert.IsNotEmpty(Validator.ErrorMessage, string.Format(CultureInfo.InvariantCulture, "Input arguments: {0}", args));
        }

        protected abstract IEnumerable<ValidationCollection> SuccessTestArgs();

        protected abstract IEnumerable<ValidationCollection> FailTestArgs();

        protected abstract void SetupInternal();
    }
}
