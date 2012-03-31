// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.ObjectModel;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Console;
using Moq;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands
{
    [TestFixture]
    public class HelpCommandTests
    {
        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.HelpCommand", Justification = "Unit test needs it")]
        [ExpectedException(typeof(AggregateException))]
        public void Constructor_NullCommand_Throws()
        {
            new HelpCommand(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Excecute_NullConsole_Throws()
        {
            var commands = CreateCommands();
            var help = new HelpCommand(commands);

            help.Execute(null, null);
        }

        [Test]
        public void Excecute_NullArgs_WriteListOfCommands()
        {
            var mockConsole = new Mock<IConsole>();
            var commands = CreateCommands();

            var help = new HelpCommand(commands);

            help.Execute(mockConsole.Object, null);

            mockConsole.Verify(console => console.WriteLine(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void Excecute_EmptyArgs_WriteListOfCommands()
        {
            var mockConsole = new Mock<IConsole>();
            var commands = CreateCommands();
            var help = new HelpCommand(commands);

            help.Execute(mockConsole.Object, new string[0]);
            mockConsole.Verify(console => console.WriteLine(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void Execute_UnknownCommandName_WriteUnknownCommandMessage()
        {
            var mockConsole = new Mock<IConsole>();
            var commands = CreateCommands();
            var help = new HelpCommand(commands);

            help.Execute(mockConsole.Object, new[] { "unknown" });
            mockConsole.Verify(console => console.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void Execute_CorrectCommandNameIsUsed_WriteCommandHelp()
        {
            var mockConsole = new Mock<IConsole>();
            var commands = CreateCommands();
            var help = new HelpCommand(commands);

            help.Execute(mockConsole.Object, new[] { commands[0].Name });
            mockConsole.Verify(console => console.WriteLine(It.IsAny<string>()), Times.AtLeast(1));
        }

        [Test]
        public void Name_Test()
        {
            const string ExpectedName = "Help";
            
            var commands = CreateCommands();
            var help = new HelpCommand(commands);

            var result = help.Name;

            Assert.AreEqual(ExpectedName, result);
        }

        [Test]
        public void Description_Test()
        {
            const string ExpectedDescripiton = "Provides help on available commands";

            var commands = CreateCommands();
            var help = new HelpCommand(commands);

            var result = help.Description;

            Assert.AreEqual(ExpectedDescripiton, result);
        }

        [Test]
        public void Parameters_Tests()
        {
            var commands = CreateCommands();
            var help = new HelpCommand(commands);

            var result = help.Parameters;

            Assert.IsNotEmpty(result);
        }

        private static Collection<ICommand> CreateCommands()
        {
            const int CommandsCount = 3;
            var commandsList = new Collection<ICommand>();

            for (var i = 0; i < CommandsCount; i++)
            {
                commandsList.Add(FakeCreator.CreateCommand(FakeCreator.CommandName + i));
            }

            return commandsList;
        }
    }
}
