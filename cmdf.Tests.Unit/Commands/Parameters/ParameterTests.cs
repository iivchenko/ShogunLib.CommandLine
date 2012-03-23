// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;
using CommandLineInterpreterFramework.Commands.Parameters.ParameterLimitation;
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
            var limiter = FakeCreator.CreateParameterLimiter(true);
            var validator = FakeCreator.CreateArgumentValidator(true);
            
            new Parameter(null, limiter, validator);
        }
        
        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Parameters.Parameter", Justification = "Unit test needs it")]
        public void Constructor_NullLimiter_Throws()
        {
            var info = FakeCreator.CreateParameterInfo();
            var validator = FakeCreator.CreateArgumentValidator(true);

            new Parameter(info, null, validator);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Parameters.Parameter", Justification = "Unit test needs it")]
        public void Constructor_NullArgumentValidatorLimiter_Throws()
        {
            var info = FakeCreator.CreateParameterInfo();
            var limiter = FakeCreator.CreateParameterLimiter(true);

            new Parameter(info, limiter, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validate_NullArguments_Throws()
        {
            var info = FakeCreator.CreateParameterInfo();
            var limiter = FakeCreator.CreateParameterLimiter(true);
            var validator = FakeCreator.CreateArgumentValidator(true);

            var parameter = new Parameter(info, limiter, validator);
            
            parameter.Validate(null);
        }

        [Test]
        [ExpectedException(typeof(ParameterLimitException))]
        public void Validate_ErrorLimit_Throws()
        {
            var args = new Collection<string>();

            var info = FakeCreator.CreateParameterInfo();
            var limiter = FakeCreator.CreateParameterLimiter(false);
            var validator = FakeCreator.CreateArgumentValidator(true);

            var parameter = new Parameter(info, limiter, validator);
            
            parameter.Validate(args);
        }

        [Test]
        [ExpectedException(typeof(ArgumentValidationException))]
        public void Validate_ErrorArgument_Throws()
        {
            var args = new[] { FakeCreator.ParameterName + "hello" };
            
            var info = FakeCreator.CreateParameterInfo();
            var limiter = FakeCreator.CreateParameterLimiter(true);
            var validator = FakeCreator.CreateArgumentValidator(false);

            var parameter = new Parameter(info, limiter, validator);

            parameter.Validate(args);
        }

        [Test]
        public void Validate_AllConditionsAreMet_RetunrnsArgument()
        {
            var args = new[] { FakeCreator.ParameterName + "hello", "fake:fakehello", FakeCreator.ParameterName + "hi" };
            var excpectedArgs = new[] { "hello", "hi" };

            var info = FakeCreator.CreateParameterInfo();
            var limiter = FakeCreator.CreateParameterLimiter(true);
            var validator = FakeCreator.CreateArgumentValidator(true);

            var parameter = new Parameter(info, limiter, validator);
            
            var argument = parameter.Validate(args);

            Assert.IsNotNull(argument);
            Assert.AreEqual(FakeCreator.ParameterName, argument.Name);
            Assert.IsTrue(excpectedArgs.SequenceEqual(argument.Values), "Actual arguments must equals to expected arguments");
        }
    }
}
