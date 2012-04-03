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
    // TODO: Finish
    [TestFixture]
    public class MultipleParameterTests : BaseValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            Validator = new MultipleParameterValidator();
            SuccessTestArgs = new List<int>();

            FialTestArgs = new[]
                               {
                                   new string[0], 
                               };
        }
    }
}
