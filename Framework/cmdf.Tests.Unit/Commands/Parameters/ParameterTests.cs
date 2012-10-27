// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Linq;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands.Parameters
{
    [TestFixture]
    public class ParameterTests
    {
        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Parameters.Parameter", Justification = "Unit test need it")]
        [ExpectedException(typeof(AggregateException))]
        public void Constructor_NullParameterInfo_Throws()
        {
            var validator = FakeCreator.CreateArgumentValidator(true);
            
            new Parameter(null, validator);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Parameters.Parameter", Justification = "Unit test needs it")]
        public void Constructor_NullArgumentValidatorLimiter_Throws()
        {
            var info = FakeCreator.CreateParameterInfo();

            new Parameter(info, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validate_NullArguments_Throws()
        {
            var info = FakeCreator.CreateParameterInfo();
            var validator = FakeCreator.CreateArgumentValidator(true);

            var parameter = new Parameter(info, validator);
            
            parameter.Validate(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentValidationException))]
        public void Validate_ErrorArgument_Throws()
        {
            var args = new[]
                           {
                               FakeCreator.ParameterName + "hello"
                           };
            
            var info = FakeCreator.CreateParameterInfo();
            var validator = FakeCreator.CreateArgumentValidator(false);

            var parameter = new Parameter(info, validator);

            parameter.Validate(args);
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
