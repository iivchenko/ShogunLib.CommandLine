﻿// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using CommandLineInterpreterFramework.ParameterLimitation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.ParameterLimitation
{
    [TestFixture]
    public class MultipleParameterTests : BaseParameterLimiterTests
    {
        [SetUp]
        public void Setup()
        {
            ParameterLimiter = new MultipleParameter();
        }

        [TestCase((uint)1)]
        [TestCase((uint)2)]
        [TestCase((uint)1000)]
        public void IsValid_Valid_ErrorMessageEmpty(uint count)
        {
            IsValid_Valid_ErrorMessageEmpty_Test(count);
        }

        [TestCase((uint)0)]
        public void IsValid_Invalid_ErrorMessageNotEmpty(uint count)
        {
            IsValid_Invalid_ErrorMessageNotEmpty_Test(count);
        }
    }
}
