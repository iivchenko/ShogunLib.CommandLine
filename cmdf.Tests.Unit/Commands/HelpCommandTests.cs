// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

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
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.HelpCommand", Justification = "Unit test needs it")]
        public void Constructor_NullConsole_Throws()
        {
            new HelpCommand(null, new Collection<ICommand>());
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.HelpCommand", Justification = "Unit test needs it")]
        [ExpectedException(typeof(AggregateException))]
        public void Constructor_NullCommand_Throws()
        {
            var stubConsole = new Mock<IConsole>();

            new HelpCommand(stubConsole.Object, null);
        }

        [Test]
        public void Excecute_NullArgs_WriteListOfCommands()
        {
            var mockConsole = new Mock<IConsole>();
            var commands = CreateCommands();

            var help = new HelpCommand(mockConsole.Object, commands);

            help.Execute(null);

            mockConsole.Verify(console => console.WriteLine(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void Excecute_EmptyArgs_WriteListOfCommands()
        {
            var mockConsole = new Mock<IConsole>();
            var commands = CreateCommands();
            var help = new HelpCommand(mockConsole.Object, commands);

            help.Execute(new string[0]);
            mockConsole.Verify(console => console.WriteLine(It.IsAny<string>()), Times.Exactly(3));
        }

        [Test]
        public void Execute_UnknownCommandName_WriteUnknownCommandMessage()
        {
            var mockConsole = new Mock<IConsole>();
            var commands = CreateCommands();
            var help = new HelpCommand(mockConsole.Object, commands);
            
            help.Execute(new[] {"unknown"});
            mockConsole.Verify(console => console.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void Execute_CorrectCommandNameIsUsed_WriteCommandHelp()
        {
            var mockConsole = new Mock<IConsole>();
            var commands = CreateCommands();
            var help = new HelpCommand(mockConsole.Object, commands);

            help.Execute(new[] {commands[0].Name});
            mockConsole.Verify(console => console.WriteLine(It.IsAny<string>()), Times.AtLeast(1));
        }

        // TODO: Hm... may be refactor?
        private static ICommand[] CreateCommands()
        {
            var stubCommand1 = FakeCreator.CreateCommand(FakeCreator.CommandName);
            var stubCommand2 = FakeCreator.CreateCommand(FakeCreator.CommandName);
            var stubCommand3 = FakeCreator.CreateCommand(FakeCreator.CommandName);

            var commands = new[]
                               {
                                   stubCommand1, 
                                   stubCommand2, 
                                   stubCommand3
                               };

            return commands;
        }
    }
}
