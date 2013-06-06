// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;
using Moq;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands.Parameters.ArgumentValidation
{
    [TestFixture]
    public class CompositeArgumentValidatorTests
    {
        private CompositeArgumentValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new CompositeArgumentValidator();
        }

        [Test]
        public void Validate_Succeeded_ReturnsTrue()
        {
            var validator = CreateValidator(true);

            _validator.Add(validator);

            var result = _validator.Validate(new List<string>());

            Assert.IsTrue(result);
        }

        [Test]
        public void Validate_Succeeded_EmptyErrorMessage()
        {
            var validator = CreateValidator(true);

            _validator.Add(validator);

            _validator.Validate(new List<string>());

            Assert.IsEmpty(_validator.ErrorMessage);
        }

        [Test]
        public void Validate_Fail_ReturnsFalse()
        {
            var validator = CreateValidator(false);
            _validator.Add(validator);

            var result = _validator.Validate(new List<string>());

            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_Fail_NotEmptyErrorMessage()
        {
            var validator = CreateValidator(false);

            _validator.Add(validator);

            _validator.Validate(new List<string>());

            Assert.IsNotEmpty(_validator.ErrorMessage);
        }

        private static IArgumentValidator CreateValidator(bool validationResult)
        {
            var validator = new Mock<IArgumentValidator>();

            validator.Setup(x => x.Validate(It.IsAny<IEnumerable<string>>())).Returns(validationResult);
            
            if (validationResult)
            {
                validator.Setup(x => x.ErrorMessage).Returns(string.Empty);
            }
            else
            {
                validator.Setup(x => x.ErrorMessage).Returns("Error message");
            }

            return validator.Object;
        }
    }
}
