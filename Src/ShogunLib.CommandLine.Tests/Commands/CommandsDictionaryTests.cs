// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
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
        public void Add_NullCommand_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _commandsDictionary.Add(null));
        }

        [Test]
        public void Add_CommandNullName_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => _commandsDictionary.Add(FakeCreator.CreateCommand(null)));
        }

        [Test]
        public void Add_CommandEmptyName_Throws()
        {
            Assert.Throws<ArgumentException>(() => _commandsDictionary.Add(FakeCreator.CreateCommand(string.Empty)));
        }

        [Test]
        public void Add_CommandWhiteSpacesName_Throws()
        {
            Assert.Throws<ArgumentException>(() => _commandsDictionary.Add(FakeCreator.CreateCommand("   ")));
        }
    }
}
