// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Globalization;

namespace ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation
{
    /// <summary>
    /// This is compositor for different argument validators.
    /// </summary>
    public sealed class CompositeArgumentValidator : IArgumentValidator
    {
        private readonly IList<IArgumentValidator> _validators;

        /// <summary>
        /// Initializes a new instance of the CompositeArgumentValidator class.
        /// </summary>
        public CompositeArgumentValidator()
        {
            _validators = new List<IArgumentValidator>();
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// Gets the error validation message if validation is failed.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Adds specific validator to the validators list.
        /// </summary>
        /// <param name="argumentValidator">Specific argument validator.</param>
        public void Add(IArgumentValidator argumentValidator)
        {
            _validators.Add(argumentValidator);
        }

        /// <summary>
        /// Validate console command arguments.
        /// </summary>
        /// <param name="args">Input arguments.</param>
        /// <returns>true - validation succeeded; false - fail.</returns>
        public bool Validate(IEnumerable<string> args)
        {
            args.ValidateNull(nameof(args));

            var error = ErrorMessage = string.Empty;

            foreach (var validator in _validators)
            {
                if (!validator.Validate(args))
                {
                    error = string.IsNullOrEmpty(error)
                                ? string.Format(CultureInfo.InvariantCulture, "{0}", validator.ErrorMessage)
                                : string.Format(CultureInfo.InvariantCulture, "{0}\n{1}", error, validator.ErrorMessage);
                }
            }

            if (!string.IsNullOrEmpty(error))
            {
                ErrorMessage = error;
                return false;
            }

            return true;
        }
    }
}
