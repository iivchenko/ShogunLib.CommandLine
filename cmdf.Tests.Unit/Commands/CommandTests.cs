// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters;
using Moq;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands
{
    [TestFixture]
    public class CommandTests
    {
        private const string Name = "Command";
        private const string Description = "Command description";
        
        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullName_Throws()
        {
            new Command(null, Description, new Collection<IParameter>(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_EmptyName_Throws()
        {
            new Command(string.Empty, Description, new Collection<IParameter>(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesName_Throws()
        {
            new Command("   ", Description, new Collection<IParameter>(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullDescription_Throws()
        {
            new Command(Name, null, new Collection<IParameter>(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_EmptyDescription_Throws()
        {
            new Command(Name, string.Empty, new Collection<IParameter>(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesDescription_Throws()
        {
            new Command(Name, "   ", new Collection<IParameter>(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullParameters_Throws()
        {
            new Command(Name, Description, null, delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullAction_Throws()
        {
            new Command(Name, Description, new Collection<IParameter>(), null);
        }

        [Test]
        public void Parameters_NoParameters_ReturnsEmptyString()
        {
            var command = new Command(Name, Description, new Collection<IParameter>(), delegate { });

            Assert.IsEmpty(command.Parameters);
        }

        [Test]
        public void Parameters_CorrectParametersAreUsed_ReturnsCorrectParamentersInfo()
        {
            var expectedParameters = new[]
                                         {
                                             FakeCreator.CreateParameterInfo("parameter1", "description1"),
                                             FakeCreator.CreateParameterInfo("parameter2", "description2")
                                         };

            var commandParameters = new[]
                                        {
                                            FakeCreator.CreateParameter("parameter1", "description1"),
                                            FakeCreator.CreateParameter("parameter2", "description2")
                                        };

            var command = new Command(Name, Description, commandParameters, delegate { });

            Assert.IsTrue(expectedParameters.SequenceEqual(command.Parameters, new ParameterInfoComparer()), "Actual parameters should be equal to expected parameters");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_NullArguments_Throws()
        {
            var command = new Command(Name, Description, new Collection<IParameter>(), delegate { });

            command.Execute(null);
        }

        [Test]
        public void Execute_Validation_ParameterValidationIsUsed()
        {
            var mockParameter = new Mock<IParameter>();
            mockParameter.Setup(parameter => parameter.Validate(It.IsAny<IEnumerable<string>>())).Returns(new Argument("name", new List<string>()));

            var parameters = new[]
                                 {
                                     mockParameter.Object
                                 };

            var command = new Command(Name, Description, parameters, delegate { });

            command.Execute(new Collection<string>());

            mockParameter.Verify(parameter => parameter.Validate(It.IsAny<IEnumerable<string>>()), Times.Once());
        }

        [Test]
        public void Execute_AllConditionsAreMet_ActionIsExecuted()
        {
            var isActionExecuted = false;
            var command = new Command(Name, Description, new Collection<IParameter>(), actionArgument => isActionExecuted = true);

            command.Execute(new Collection<string>());

            Assert.IsTrue(isActionExecuted, "Command should execute Action delegate");
        }

        private class ParameterInfoComparer : EqualityComparer<IParameterInfo>
        {
            public override bool Equals(IParameterInfo x, IParameterInfo y)
            {
                return x.Name == y.Name && x.Description == y.Description;
            }

            public override int GetHashCode(IParameterInfo obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
