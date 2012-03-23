// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using CommandLineInterpreterFramework.Commands.Parameters.ParameterLimitation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands.Parameters.ParameterLimitation
{
    [TestFixture]
    public abstract class BaseParameterLimiterTests
    {
        protected IParameterLimiter ParameterLimiter { get; set; }

        protected void IsValid_Valid_ErrorMessageEmpty_Test(uint count)
        {
            var isValid = ParameterLimiter.Validate(count);

            Assert.IsTrue(isValid);
            Assert.IsEmpty(ParameterLimiter.ErrorMessage);
        }

        protected void IsValid_Invalid_ErrorMessageNotEmpty_Test(uint count)
        {
            var isValid = ParameterLimiter.Validate(count);

            Assert.IsFalse(isValid);
            Assert.IsNotEmpty(ParameterLimiter.ErrorMessage);
        }
    }
}
