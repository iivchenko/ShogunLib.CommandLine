// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.FileSystemValidation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands.Parameters.ArgumentValidation.FileSystemValidation
{
    [TestFixture]
    public sealed class DriveExistsTests : BaseValidatorTests
    {
        protected override IEnumerable<ValidationCollection> SuccessTestArgs()
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

        protected override IEnumerable<ValidationCollection> FailTestArgs()
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
