// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using CommandLineInterpreterFramework.Common.Strings;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Common.Strings
{
    // TODO: Feature of the next version
    [TestFixture]
    public class StringWrapperTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("Hello")]
        public void AsString_Tests(string value)
        {
            var stringWrapper = new StringWrapper(value);

            Assert.AreEqual(value, stringWrapper.AsString());
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("Hello")]
        public void ToString_Tests(string value)
        {
            var stringWrapper = new StringWrapper(value);

            Assert.AreEqual(value, stringWrapper.ToString());
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("Hello")]
        public void AsString_Tests_TheSameAsToString(string value)
        {
            var stringWrapper = new StringWrapper(value);

            Assert.AreEqual(stringWrapper.ToString(), stringWrapper.AsString());
        }
    }
}
