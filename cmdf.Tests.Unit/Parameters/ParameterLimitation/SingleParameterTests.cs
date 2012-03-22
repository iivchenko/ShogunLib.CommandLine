// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using CommandLineInterpreterFramework.Parameters.ParameterLimitation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Parameters.ParameterLimitation
{
    [TestFixture]
    public class SingleParameterTests : BaseParameterLimiterTests
    {
        [SetUp]
        public void Setup()
        {
            ParameterLimiter = new SingleParameter();
        }

        [TestCase((uint)1)]
        public void IsValid_Valid_ErrorMessageEmpty(uint count)
        {
            IsValid_Valid_ErrorMessageEmpty_Test(count);
        }

        [TestCase((uint)0)]
        [TestCase((uint)2)]
        [TestCase((uint)3)]
        [TestCase((uint)4)]
        [TestCase((uint)1000)]
        public void IsValid_Invalid_ErrorMessageNotEmpty(uint count)
        {
            IsValid_Invalid_ErrorMessageNotEmpty_Test(count);
        }
    }
}
