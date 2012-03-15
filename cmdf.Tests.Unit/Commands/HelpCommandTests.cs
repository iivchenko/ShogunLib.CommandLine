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

        private static ICommand[] CreateCommands()
        {
            var stubCommand1 = new Mock<ICommand>();
            var stubCommand2 = new Mock<ICommand>();
            var stubCommand3 = new Mock<ICommand>();

            stubCommand1.Setup(command => command.Name).Returns("Command1");
            stubCommand2.Setup(command => command.Name).Returns("Command2");
            stubCommand3.Setup(command => command.Name).Returns("Command3");

            stubCommand1.Setup(command => command.Parameters).Returns(new[] { new ParameterInfo("param1", "descripiton1") });
            stubCommand2.Setup(command => command.Parameters).Returns(new[] { new ParameterInfo("param2", "descripiton2") });
            stubCommand3.Setup(command => command.Parameters).Returns(new[] { new ParameterInfo("param3", "descripiton3") });

            var commands = new[]
                               {
                                   stubCommand1.Object, 
                                   stubCommand2.Object, 
                                   stubCommand3.Object
                               };

            return commands;
        }
    }
}
