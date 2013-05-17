// <copyright company="AppAssure Software, Inc.">
//     Confidential and Proprietary
//     Copyright (c) 2012 AppAssure Software, Inc. All rights Reserved. ††
// </copyright>

using System.Collections.Generic;
using System.Globalization;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.TypeValidation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands.Parameters.ArgumentValidation.TypeValidation
{
    [TestFixture]
    public class UIntTypeValidatorTests : BaseValidatorTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            Validator = new UIntTypeValidator();
        }

        protected override IEnumerable<ValidationCollection> SuccessTestArgs()
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

        protected override IEnumerable<ValidationCollection> FailTestArgs()
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
    }
}
