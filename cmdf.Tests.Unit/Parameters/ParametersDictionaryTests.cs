// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using CommandLineInterpreterFramework.Parameters;
using Moq;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Parameters
{
    [TestFixture]
    public class ParametersDictionaryTests
    {
        private const string Description = "Description";

        private ParametersDictionary _parametersDictionary;

        [SetUp]
        public void Setup()
        {
            _parametersDictionary = new ParametersDictionary();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullParameter_Throws()
        {
            _parametersDictionary.Add(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ParameterNullName_Throws()
        {
            _parametersDictionary.Add(CreateParameter(null, Description));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ParameterEmptyName_Throws()
        {
            _parametersDictionary.Add(CreateParameter(string.Empty, Description));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ParameterWhiteSpacesName_Throws()
        {
            _parametersDictionary.Add(CreateParameter("   ", Description));
        }

        private static IParameter CreateParameter(string name, string description)
        {
            var stubParameter = new Mock<IParameter>();
            var stubParameterInfo = new Mock<IParameterInfo>();

            stubParameterInfo.Setup(parameterInfo => parameterInfo.Name).Returns(name);
            stubParameterInfo.Setup(parameterInfo => parameterInfo.Description).Returns(description);
            
            stubParameter.Setup(parameter => parameter.Info).Returns(stubParameterInfo.Object);

            return stubParameter.Object;
        }
    }
}
