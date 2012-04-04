// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.LimitValidation;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands.Parameters.ArgumentValidation.LimitValidation
{
    [TestFixture]
    public class SingleParameterTests : BaseValidatorTests
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            Validator = new SingleParameterValidator();
        }

        protected override IEnumerable<ValidationCollection> SuccessTestArgs()
        {
            return new[]
                       {
                           new ValidationCollection
                               {
                                   "hello1",
                               }
                       };
        }

        protected override IEnumerable<ValidationCollection> FailTestArgs()
        {
            return new[]
                       {
                           new ValidationCollection(),
                           new ValidationCollection
                               {
                                   "hello1",
                                   "hello2"
                               },
                           new ValidationCollection
                               {
                                   "hello1",
                                   "hello2",
                                   "hello3"
                               },
                           new ValidationCollection
                               {
                                   "hello1",
                                   "hello2",
                                   "hello3",
                                   "hello4"
                               }
                       };
        }
    }
}
