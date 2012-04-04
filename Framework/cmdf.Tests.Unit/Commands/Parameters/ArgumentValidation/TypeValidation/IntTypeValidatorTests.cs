// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using System.Globalization;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.TypeValidation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands.Parameters.ArgumentValidation.TypeValidation
{
    [TestFixture]
    public class IntTypeValidatorTests : BaseValidatorTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            Validator = new IntTypeValidator();
        }

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
    }
}
