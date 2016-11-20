// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation.TextValidation
{
    /// <summary>
    /// Validate if specified arguments belongs to the predefined values. Case not sensitive search.
    /// </summary>
    public sealed class CaseNotSensitiveMatchStringValidator : IArgumentValidator
    {
        private readonly IList<string> _templates;

        /// <summary>
        /// Initializes a new instance of the CaseNotSensitiveMatchStringValidator class.
        /// </summary>
        /// <param name="templates">Predefined values that will be used during argument validation.</param>
        public CaseNotSensitiveMatchStringValidator(IEnumerable<string> templates)
        {
            _templates = new List<string>(templates);
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// Gets the error validation message if validation is failed.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Validate console command arguments.
        /// </summary>
        /// <param name="args">Input arguments.</param>
        /// <returns>true - validation succeeded; false - fail.</returns>
        public bool Validate(IEnumerable<string> args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            var notMatches = args.Where(arg => !_templates.Select(template => template.ToUpperInvariant()).Contains(arg.ToUpperInvariant())).ToList();

            if (notMatches.Count > 0)
            {
                ErrorMessage = string.Format(CultureInfo.InvariantCulture,
                                             "Next parameters are invalid: {0}. Use among this: {1}",
                                             string.Join(" ; ", notMatches),
                                             string.Join(" ; ", _templates));

                return false;
            }

            return true;
        }
    }
}
