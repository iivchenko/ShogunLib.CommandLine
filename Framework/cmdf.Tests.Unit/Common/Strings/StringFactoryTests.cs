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
    public class StringFactoryTests
    {
        private StringFactory _stringFactory;

        [SetUp]
        public void Setup()
        {
            _stringFactory = new StringFactory();
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "StringWrapper", Justification = "This is a type name")]
        public void Create_CheckResultType_StringWrapperType()
        {
            var stringWripper = _stringFactory.Create(string.Empty);

            Assert.NotNull(stringWripper as StringWrapper, "Result should be an StringWrapper Type");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("Hello")]
        public void Create_Tests(string value)
        {
            var stringWripper = _stringFactory.Create(value);

            Assert.AreEqual(value, stringWripper.AsString());
        }
    }
}
