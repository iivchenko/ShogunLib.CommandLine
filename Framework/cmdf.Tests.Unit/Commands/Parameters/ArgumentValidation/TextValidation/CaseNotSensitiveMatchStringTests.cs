// <copyright company="AppAssure Software, Inc.">
//     Confidential and Proprietary
//     Copyright (c) 2012 AppAssure Software, Inc. All rights Reserved. ††
// </copyright>

using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.TextValidation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands.Parameters.ArgumentValidation.TextValidation
{
    [TestFixture]
    public sealed class CaseNotSensitiveMatchStringTests : BaseValidatorTests
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

                           new ValidationCollection
                               {
                                   "TEST1"
                               },

                           new ValidationCollection
                               {
                                   "test2"
                               },
                       };
        }

        protected override IEnumerable<ValidationCollection> FailTestArgs()
        {
            return new[]
                       {
                           new ValidationCollection
                               {
                                   " Test1",
                                   "Test1 "
                               }
                       };
        }

        protected override void SetupInternal()
        {
            Validator = new CaseNotSensitiveMatchStringValidator(new List<string> { "Test1", "TEST2" });
        }
    }
}
