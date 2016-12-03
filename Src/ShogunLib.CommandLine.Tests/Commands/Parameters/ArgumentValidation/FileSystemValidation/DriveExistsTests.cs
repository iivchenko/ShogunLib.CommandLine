// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using NUnit.Framework;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation.FileSystemValidation;

namespace ShogunLib.CommandLine.Tests.Commands.Parameters.ArgumentValidation.FileSystemValidation
{
    [TestFixture]
    public sealed class DriveExistsTests : BaseValidatorTests
    {
        public static IEnumerable<ValidationCollection> SuccessTestArgs()
        {
            return new[]
                       {
                           new ValidationCollection
                               {
                                   "C:\\",
                                   "C:\\Hello\\"
                               }
                       };
        }

        public static IEnumerable<ValidationCollection> FailTestArgs()
        {
            return new[]
                       {
                           new ValidationCollection
                               {
                                   "2:\\",
                                   "2:\\Hello\\"
                               }
                       };
        }

        protected override void SetupInternal()
        {
            Validator = new DriveExistsValidator();
        }
    }
}
