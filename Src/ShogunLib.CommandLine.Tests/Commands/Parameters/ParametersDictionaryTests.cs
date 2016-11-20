// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using NUnit.Framework;
using ShogunLib.CommandLine.Commands.Parameters;

namespace ShogunLib.CommandLine.Tests.Commands.Parameters
{
    [TestFixture]
    public class ParametersDictionaryTests
    {
        private ParametersDictionary _parametersDictionary;

        [SetUp]
        public void Setup()
        {
            _parametersDictionary = new ParametersDictionary();
        }

        [Test]
        public void Add_NullParameter_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _parametersDictionary.Add(null));
        }

        [Test]
        public void Add_ParameterNullName_Throws()
        {
            var parameter = FakeCreator.CreateParameter(null, FakeCreator.ParameterDescription);

            Assert.Throws<ArgumentNullException>(() => _parametersDictionary.Add(parameter));
        }

        [Test]
        public void Add_ParameterEmptyName_Throws()
        {
            var parameter = FakeCreator.CreateParameter(string.Empty, FakeCreator.ParameterDescription);

            Assert.Throws<ArgumentException>(() => _parametersDictionary.Add(parameter));
        }

        [Test]
        public void Add_ParameterWhiteSpacesName_Throws()
        {
            var parameter = FakeCreator.CreateParameter("   ", FakeCreator.ParameterDescription);

            Assert.Throws<ArgumentException>(() => _parametersDictionary.Add(parameter));
        }
    }
}
