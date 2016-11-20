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
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullParameter_Throws()
        {
            _parametersDictionary.Add(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ParameterNullName_Throws()
        {
            var parameter = FakeCreator.CreateParameter(null, FakeCreator.ParameterDescription);

            _parametersDictionary.Add(parameter);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ParameterEmptyName_Throws()
        {
            var parameter = FakeCreator.CreateParameter(string.Empty, FakeCreator.ParameterDescription);

            _parametersDictionary.Add(parameter);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ParameterWhiteSpacesName_Throws()
        {
            var parameter = FakeCreator.CreateParameter("   ", FakeCreator.ParameterDescription);

            _parametersDictionary.Add(parameter);
        }
    }
}
