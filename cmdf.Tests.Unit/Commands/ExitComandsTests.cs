// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using CommandLineInterpreterFramework.Commands;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands
{
    [TestFixture]
    public class ExitComandsTests
    {
        private ExitCommand _exitCommand;

        [SetUp]
        public void Setup()
        {
            _exitCommand = new ExitCommand();
        }

        [Test]
        public void Name_Test()
        {
            const string ExpectedName = "Exit";
            var result = _exitCommand.Name;

            Assert.AreEqual(ExpectedName, result);
        }

        [Test]
        public void Description_Test()
        {
            const string ExpectedDescripiton = "Doesn't do anything";
            var result = _exitCommand.Description;

            Assert.AreEqual(ExpectedDescripiton, result);
        }

        [Test]
        public void Parameters_Tests()
        {
            var result = _exitCommand.Parameters;

            Assert.IsEmpty(result);
        }

        [Test]
        public void Execute_DoNothing()
        {
            _exitCommand.Execute(null, null);
        }
    }
}
