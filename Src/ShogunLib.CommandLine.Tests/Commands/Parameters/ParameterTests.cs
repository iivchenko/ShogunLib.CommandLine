// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Linq;
using NUnit.Framework;
using ShogunLib.CommandLine.Commands.Parameters;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation;

namespace ShogunLib.CommandLine.Tests.Commands.Parameters
{
    [TestFixture]
    public class ParameterTests
    {
        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Parameters.Parameter", Justification = "Unit test need it")]
        public void Constructor_NullParameterInfo_Throws()
        {
            var validator = FakeCreator.CreateArgumentValidator(true);

            Assert.Throws<AggregateException>(() => new Parameter(null, validator));
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Parameters.Parameter", Justification = "Unit test needs it")]
        public void Constructor_NullArgumentValidatorLimiter_Throws()
        {
            var info = FakeCreator.CreateParameterInfo();

            Assert.Throws<AggregateException>(() => new Parameter(info, null));
        }

        [Test]
        public void Validate_NullArguments_Throws()
        {
            var info = FakeCreator.CreateParameterInfo();
            var validator = FakeCreator.CreateArgumentValidator(true);

            var parameter = new Parameter(info, validator);

            Assert.Throws<ArgumentNullException>(() => parameter.Validate(null));
        }

        [Test]
        public void Validate_ErrorArgument_Throws()
        {
            var args = new[]
                           {
                               FakeCreator.ParameterName + "hello"
                           };
            
            var info = FakeCreator.CreateParameterInfo();
            var validator = FakeCreator.CreateArgumentValidator(false);

            var parameter = new Parameter(info, validator);

            Assert.Throws<ArgumentValidationException>(() => parameter.Validate(args));
        }

        [Test]
        public void Validate_AllConditionsAreMet_ReturnsArgument()
        {
            var args = new[]
                           {
                               FakeCreator.ParameterName + "hello", 
                               "fake:fakehello", 
                               FakeCreator.ParameterName + "hi"
                           };

            var excpectedArgs = new[]
                                    {
                                        "hello", 
                                        "hi"
                                    };

            var info = FakeCreator.CreateParameterInfo();
            var validator = FakeCreator.CreateArgumentValidator(true);

            var parameter = new Parameter(info, validator);
            
            var argument = parameter.Validate(args);

            Assert.IsNotNull(argument);
            Assert.AreEqual(FakeCreator.ParameterName, argument.Name);
            Assert.IsTrue(excpectedArgs.SequenceEqual(argument.Values), "Actual arguments must equals to expected arguments");
        }

        [Test]
        public void Info_Test()
        {
            var expectedInfo = FakeCreator.CreateParameterInfo();
            var validator = FakeCreator.CreateArgumentValidator(true);

            var parameter = new Parameter(expectedInfo, validator);

            Assert.AreEqual(expectedInfo, parameter.Info);
        }
    }
}
