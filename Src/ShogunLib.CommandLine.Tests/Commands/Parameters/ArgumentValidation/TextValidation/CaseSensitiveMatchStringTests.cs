// <copyright company="AppAssure Software, Inc.">
//     Confidential and Proprietary
//     Copyright (c) 2012 AppAssure Software, Inc. All rights Reserved. ††
// </copyright>

using System.Collections.Generic;
using NUnit.Framework;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation.TextValidation;

namespace ShogunLib.CommandLine.Tests.Commands.Parameters.ArgumentValidation.TextValidation
{
    [TestFixture]
    public sealed class CaseSensitiveMatchStringTests : BaseValidatorTests
    {
        protected override IEnumerable<ValidationCollection> SuccessTestArgs()
        {
            return new[]
                       {
                           new ValidationCollection
                               {
                                   "Test1",
                                   "TEST2"
                               },

                           new ValidationCollection
                               {
                                   "Test1"
                               },

                           new ValidationCollection
                               {
                                   "TEST2"
                               },
                       };
        }

        protected override IEnumerable<ValidationCollection> FailTestArgs()
        {
            return new[]
                       {
                           new ValidationCollection
                               {
                                   "TEST1",
                                   "test2",
                                   " Test1",
                                   "Test1 "
                               }
                       };
        }

        protected override void SetupInternal()
        {
            Validator = new CaseSensitiveMatchStringValidator(new List<string> { "Test1", "TEST2" });
        }
    }
}
