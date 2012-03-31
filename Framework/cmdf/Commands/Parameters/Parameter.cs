// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;
using CommandLineInterpreterFramework.Commands.Parameters.ParameterLimitation;

namespace CommandLineInterpreterFramework.Commands.Parameters
{
    /// <summary>
    /// Lazy realization of the the console command parameter
    /// </summary>
    public class Parameter : IParameter
    {
        private readonly IParameterInfo _parameterInfo;
        private readonly IParameterLimiter _parameterLimiter;
        private readonly IArgumentValidator _argumentValidator;

        /// <summary>
        /// Initializes a new instance of the Parameter class
        /// </summary>
        /// <param name="parameterInfo">Contains paramter name and description</param>
        /// <param name="parameterLimiter">Validate number of times this parameter was used in command line</param>
        /// <param name="argumentValidator">Argument validator</param>
        public Parameter(IParameterInfo parameterInfo, 
                         IParameterLimiter parameterLimiter, 
                         IArgumentValidator argumentValidator)
        {
            var exceptions = new List<Exception>();

            if (parameterInfo == null)
            {
                exceptions.Add(new ArgumentNullException("parameterInfo"));
            }

            if (parameterLimiter == null)
            {
                exceptions.Add(new ArgumentNullException("parameterLimiter"));
            }

            if (argumentValidator == null)
            {
                exceptions.Add(new ArgumentNullException("argumentValidator"));
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException("Parameter initialization fail", exceptions);
            }

            _parameterInfo = parameterInfo;
            _parameterLimiter = parameterLimiter;
            _argumentValidator = argumentValidator;
        }

        /// <summary>
        /// Gets parameter information
        /// </summary>
        public IParameterInfo Info
        {
            get { return _parameterInfo; }
        }

        /// <summary>
        /// Performs validation on the input arguments
        /// </summary>
        /// <param name="args">Input arguments</param>
        /// <exception cref="ParameterLimitException"/>
        /// <exception cref="ArgumentValidationException"/>
        /// <returns>Validated argument</returns>
        public virtual IArgument Validate(IEnumerable<string> args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            var parameterArguments = GetParametersArguments(args);

            if (!_parameterLimiter.Validate((uint)parameterArguments.Count()))
            {
                throw new ParameterLimitException(string.Format(CultureInfo.InvariantCulture, "Limitation error.\nParameter name = {0}\n{1}", _parameterInfo.Name, _parameterLimiter.ErrorMessage));
            }

            if (!_argumentValidator.Validate(parameterArguments))
            {
                throw new ArgumentValidationException(string.Format(CultureInfo.InvariantCulture, "Validation error.\nParameter name = {0}\n{1}", _parameterInfo.Name, _argumentValidator.ErrorMessage));
            }
            
            return new Argument(_parameterInfo.Name, parameterArguments);
        }

        // Find among available argumets only those that belongs to the current parameter.
        // Delete parameter prefix from argumets and returns new collection.
        private IList<string> GetParametersArguments(IEnumerable<string> args)
        {
            // arguments whith parameter prefix
            var parameters = args.Where(arg => arg.StartsWith(_parameterInfo.Name, StringComparison.OrdinalIgnoreCase)).ToList();

            // arguments whithout parameter prefix
            var arguments = new List<string>();

            foreach (var parameter in parameters)
            {
                // argument without parameter prefix
                var argument = parameter.Substring(_parameterInfo.Name.Length, parameter.Length - _parameterInfo.Name.Length);

                arguments.Add(argument);
            }

            return new Collection<string>(arguments);
        }
    }
}
