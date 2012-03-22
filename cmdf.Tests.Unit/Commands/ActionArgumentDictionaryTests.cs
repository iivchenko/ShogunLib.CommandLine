// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Parameters;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands
{
    [TestFixture]
    public class ActionArgumentDictionaryTests
    {
        private ActionArgumentDictionary _actionArgumentDictionary;

        [SetUp]
        public void Setup()
        {
            _actionArgumentDictionary = new ActionArgumentDictionary();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullArgument_Throws()
        {
            _actionArgumentDictionary.Add(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ArgumentNullName_Throws()
        {
            _actionArgumentDictionary.Add(new Argument(null, new List<string>()));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ArgumentEmptyName_Throws()
        {
            _actionArgumentDictionary.Add(new Argument(string.Empty, new List<string>()));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_ArgumentWhiteSpacesName_Throws()
        {
            _actionArgumentDictionary.Add(new Argument("   ", new List<string>()));
        }
    }
}
