// <copyright company="AppAssure Software, Inc.">
//     Confidential and Proprietary
//     Copyright (c) 2012 AppAssure Software, Inc. All rights Reserved. ††
// </copyright>

using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation.TypeValidation;

namespace ShogunLib.CommandLine.Tests.Commands.Parameters.ArgumentValidation.TypeValidation
{
    [TestFixture]
    public class UIntTypeValidatorTests : BaseValidatorTests
    {
        public static IEnumerable<ValidationCollection> SuccessTestArgs()
        {
            return new[]
                       {
                           new ValidationCollection
                               {
                                   uint.MinValue.ToString(CultureInfo.InvariantCulture),
                                   "0",
                                   "1",
                                   "2",
                                   "3",
                                   uint.MaxValue.ToString(CultureInfo.InvariantCulture)
                               }
                       };
        }

        public static IEnumerable<ValidationCollection> FailTestArgs()
        {
            return new[]
                       {
                           new ValidationCollection
                               {
                                   "a",
                                   "1.1",
                                   "1,1",
                                   ".",
                                   "-",
                                   "-1"
                               }
                       };
        }

        protected override void SetupInternal()
        {
            Validator = new UIntTypeValidator();
        }
    }
}
