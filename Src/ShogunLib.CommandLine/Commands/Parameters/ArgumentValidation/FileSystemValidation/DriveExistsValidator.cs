// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation.FileSystemValidation
{
    /// <summary>
    /// Input path should contain existing drive.
    /// </summary>
    public sealed class DriveExistsValidator : IArgumentValidator
    {
        /// <summary>
        /// Initializes a new instance of the DriveExistsValidator class.
        /// </summary>
        public DriveExistsValidator()
        {
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// Gets the validation failed message.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Performs validation of the specified parameter. Input path should contain existing drive. If not than ErrorMessage is set.
        /// </summary>
        /// <param name="args">Input arguments.</param>
        /// <returns>true - validation succeeded; false - validation filed.</returns>
        public bool Validate(IEnumerable<string> args)
        {
            args.ValidateNull(nameof(args));

            var systemDrives = DriveInfo.GetDrives();
            var fakeDrives = new List<string>();

            foreach (var arg in args)
            {
                var root = Path.GetPathRoot(arg);

                if (systemDrives.All(drive => drive.Name != root))
                {
                    fakeDrives.Add(arg);
                }
            }
            
            if (fakeDrives.Count > 0)
            {
                ErrorMessage = string.Format(CultureInfo.InvariantCulture,
                                             "Next pathes contains invalid drives: {0}",
                                             string.Join(" ; ", fakeDrives));
                return false;
            }

            ErrorMessage = string.Empty;

            return true;
        }
    }
}
