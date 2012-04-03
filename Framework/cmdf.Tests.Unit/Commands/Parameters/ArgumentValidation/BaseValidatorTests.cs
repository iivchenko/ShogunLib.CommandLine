// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands.Parameters.ArgumentValidation
{
    public abstract class BaseValidatorTests
    {
        public static IList<int> SuccessTestArgs { get; set; }

        protected IArgumentValidator Validator { get; set; }

        protected string[][] FialTestArgs { get; set; }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validate_NullArgumets_Throws()
        {
            Validator.Validate(null);
        }

        [Test, TestCaseSource("SuccessTestArgs")]
        public void Validate_Succeeded_ReturnsTrue(int a)
        {
            //var isValid = Validator.Validate(args);
            //Assert.IsTrue(isValid);
        }

        [Test, TestCaseSource("SuccessTestArgs")]
        public void Validate_Succeeded_EmptyErrorMessage(IEnumerable<string> args)
        {
            Validator.Validate(args);

            Assert.IsEmpty(Validator.ErrorMessage);
        }

        [Test, TestCaseSource("FailTestArgs")]
        public void Validate_Fail_ReturnsFalse(IEnumerable<string> args)
        {
            var isValid = Validator.Validate(args);

            Assert.IsFalse(isValid);
        }

        [Test, TestCaseSource("FailTestArgs")]
        public void Validate_Fail_NotEmptyErrorMessage(IEnumerable<string> args)
        {
            Validator.Validate(args);

            Assert.IsNotEmpty(Validator.ErrorMessage);
        }
    }
}
