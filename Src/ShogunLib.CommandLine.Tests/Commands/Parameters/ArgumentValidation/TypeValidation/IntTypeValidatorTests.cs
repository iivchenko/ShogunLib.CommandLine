// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation.TypeValidation;

namespace ShogunLib.CommandLine.Tests.Commands.Parameters.ArgumentValidation.TypeValidation
{
    [TestFixture]
    public class IntTypeValidatorTests : BaseValidatorTests
    {
        protected override IEnumerable<ValidationCollection> SuccessTestArgs()
        {
            return new[]
                       {
                           new ValidationCollection
                               {
                                   int.MinValue.ToString(CultureInfo.InvariantCulture),
                                   "-1",
                                   "0",
                                   "1",
                                   "2",
                                   "3",
                                   int.MaxValue.ToString(CultureInfo.InvariantCulture)
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
                                   "-"
                               }
                       };
        }

        protected override void SetupInternal()
        {
            Validator = new IntTypeValidator();
        }
    }
}
