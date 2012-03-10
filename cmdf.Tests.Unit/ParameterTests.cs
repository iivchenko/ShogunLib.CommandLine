// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommandLineInterpreterFramework.ArgumentValidation;
using CommandLineInterpreterFramework.ParameterLimitation;
using Moq;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit
{
    [TestFixture]
    public class ParameterTests
    {
        private const string Name = "/name:";
        private const string Description = "description";

        [Test]
        [ExpectedException(typeof(AggregateException))]
        public void Constructor_NullParameterInfo_Throws()
        {
            CreateParameter(null, true, true);
        }
        
        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Parameter", Justification = "Unit test needs it")]
        public void Constructor_NullLimiter_Throws()
        {
            var stubArgumentValidator = new Mock<IArgumentValidator>();

            new Parameter(new ParameterInfo(Name, Description), null, stubArgumentValidator.Object);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Parameter", Justification = "Unit test needs it")]
        public void Constructor_NullArgumentValidatorLimiter_Throws()
        {
            var stubLimiter = new Mock<IParameterLimiter>();

            new Parameter(new ParameterInfo(Name, Description), stubLimiter.Object, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validate_NullArguments_Throws()
        {
            var parameter = CreateParameter(true, true);
            
            parameter.Validate(null);
        }

        [Test]
        [ExpectedException(typeof(ParameterLimitException))]
        public void Validate_ErrorLimit_Throws()
        {
            var parameter = CreateParameter(false, true);

            parameter.Validate(new Collection<string>());
        }

        [Test]
        [ExpectedException(typeof(ArgumentValidationException))]
        public void Validate_ErrorArgument_Throws()
        {
            var parameter = CreateParameter(true, false);

            parameter.Validate(new[] {Name + "hello"});
        }

        [Test]
        public void Validate_AllConditionsAreMet_RetunrnsArgument()
        {
            var parameter = CreateParameter(true, true);
            var args = new[] {Name + "hello", "fake:fakehello", Name + "hi"};
            var excpectedArgs = new[] {"hello", "hi"};

            var argument = parameter.Validate(args);

            Assert.IsNotNull(argument);
            Assert.AreEqual(Name, argument.Name);
            Assert.IsTrue(excpectedArgs.SequenceEqual(argument.Values), "Actual arguments must equals to expected arguments");
        }

        private static IParameter CreateParameter(ParameterInfo parameterInfo, bool limiterResult, bool argumentValidatorResult)
        {
            var stubParameterLimiter = new Mock<IParameterLimiter>();
            var stubArgumentValidator = new Mock<IArgumentValidator>();

            stubParameterLimiter.Setup(limiter => limiter.Validate(It.IsAny<uint>())).Returns(limiterResult);
            stubArgumentValidator.Setup(validator => validator.Validate(It.IsAny<IEnumerable<string>>())).Returns(argumentValidatorResult);

            return new Parameter(parameterInfo,
                                 stubParameterLimiter.Object,
                                 stubArgumentValidator.Object);
        }

        private static IParameter CreateParameter(bool limiterResult, bool argumentValidatorResult)
        {
            return CreateParameter(new ParameterInfo(Name, Description),
                                   limiterResult,
                                   argumentValidatorResult);
        }
    }
}
