// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;
using CommandLineInterpreterFramework.Commands.Parameters.ParameterLimitation;
using Moq;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands
{
    /// <summary>
    /// This helper class should return MOCKs and STUBs only
    /// </summary>
    internal static class FakeCreator
    {
        public const string CommandName = "Command";
        public const string CommandDescription = "Description";

        public const string ParameterName = "/name:";
        public const string ParameterDescription = "Description";

        #region public Command

        public static ICommand CreateCommand(string name)
        {
            return CreateCommandInternal(name, CommandDescription, 1, ParameterName, ParameterDescription);
        }

        #endregion
        #region public Parameter

        public static IParameter CreateParameter(string name, string description)
        {
            return CreateParameterInternal(name, description, null);
        }

        #endregion
        #region public ParameterInfo

        public static IParameterInfo CreateParameterInfo()
        {
            return CreateParameterInfoInternal(ParameterName, ParameterDescription);
        }

        public static IParameterInfo CreateParameterInfo(string name, string description)
        {
            return CreateParameterInfoInternal(name, description);
        }

        #endregion
        #region public ParameterLimiter
        
        public static IParameterLimiter CreateParameterLimiter(bool validationResult)
        {
            return CreateParameterLimiterInternal(validationResult);
        }

        #endregion
        #region public ArgumentValidator

        public static IArgumentValidator CreateArgumentValidator(bool validationResult)
        {
            return CreateArgumentValidatorInternal(validationResult);
        }

        #endregion

        private static ICommand CreateCommandInternal(string commandName, string commandDescription, int parametersCount, string parametersTemplateName, string parametersTemplateDescription)
        {
            var parameters = new Collection<IParameterInfo>();

            for (var i = 0; i < parametersCount; i++)
            {
                var parameterName = string.Format(CultureInfo.InvariantCulture, "{0}{1}", parametersTemplateName, i);
                var parameterDescription = string.Format(CultureInfo.InvariantCulture, "{0}{1}", parametersTemplateDescription, i);
                var parameter = CreateParameterInfoInternal(parameterName, parameterDescription);

                parameters.Add(parameter);
            }

            var stubCommand = new Mock<ICommand>();
            stubCommand.Setup(command => command.Name).Returns(commandName);
            stubCommand.Setup(command => command.Description).Returns(commandDescription);
            stubCommand.Setup(command => command.Parameters).Returns(parameters);

            return stubCommand.Object;
        }

        private static IParameter CreateParameterInternal(string name, string description, IArgument validationResult)
        {
            var info = CreateParameterInfo(name, description);

            var stubParameter = new Mock<IParameter>();

            stubParameter.Setup(parameter => parameter.Info).Returns(info);
            stubParameter.Setup(parameter => parameter.Validate(It.IsAny<IEnumerable<string>>())).Returns(validationResult);

            return stubParameter.Object;
        }

        private static IParameterInfo CreateParameterInfoInternal(string name, string description)
        {
            var stubParameterInfo = new Mock<IParameterInfo>();

            stubParameterInfo.Setup(parameterInfo => parameterInfo.Name).Returns(name);
            stubParameterInfo.Setup(parameterInfo => parameterInfo.Description).Returns(description);

            return stubParameterInfo.Object;
        }

        private static IParameterLimiter CreateParameterLimiterInternal(bool validationResult)
        {
            var stubParameterLimiter = new Mock<IParameterLimiter>();
            stubParameterLimiter.Setup(limiter => limiter.Validate(It.IsAny<uint>())).Returns(validationResult);

            return stubParameterLimiter.Object;
        }

        private static IArgumentValidator CreateArgumentValidatorInternal(bool validationResult)
        {
            var stubArgumentValidator = new Mock<IArgumentValidator>();

            stubArgumentValidator.Setup(validator => validator.Validate(It.IsAny<IEnumerable<string>>())).Returns(validationResult);

            return stubArgumentValidator.Object;
        }
    }
}
