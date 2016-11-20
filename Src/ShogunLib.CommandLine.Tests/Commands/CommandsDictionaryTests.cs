// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using NUnit.Framework;
using ShogunLib.CommandLine.Commands;

namespace ShogunLib.CommandLine.Tests.Commands
{
    [TestFixture]
    public class CommandsDictionaryTests
    {
        private CommandsDictionary _commandsDictionary;

        [SetUp]
        public void Setup()
        {
            _commandsDictionary = new CommandsDictionary();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullCommand_Throws()
        {
            _commandsDictionary.Add(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_CommandNullName_Throws()
        {
            _commandsDictionary.Add(FakeCreator.CreateCommand(null));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_CommandEmptyName_Throws()
        {
            _commandsDictionary.Add(FakeCreator.CreateCommand(string.Empty));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_CommandWhiteSpacesName_Throws()
        {
            _commandsDictionary.Add(FakeCreator.CreateCommand("   "));
        }
    }
}
