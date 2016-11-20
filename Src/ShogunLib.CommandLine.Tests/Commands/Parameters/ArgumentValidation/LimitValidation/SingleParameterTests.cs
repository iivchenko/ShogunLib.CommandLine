// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using NUnit.Framework;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation.LimitValidation;

namespace ShogunLib.CommandLine.Tests.Commands.Parameters.ArgumentValidation.LimitValidation
{
    [TestFixture]
    public class SingleParameterTests : BaseValidatorTests
    {
        public static IEnumerable<ValidationCollection> SuccessTestArgs()
        {
            return new[]
                       {
                           new ValidationCollection
                               {
                                   "hello1",
                               }
                       };
        }

        public static IEnumerable<ValidationCollection> FailTestArgs()
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

        protected override void SetupInternal()
        {
            Validator = new SingleParameterValidator();
        }
    }
}
