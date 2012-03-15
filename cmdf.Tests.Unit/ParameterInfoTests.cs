// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit
{
    [TestFixture]
    public class ParameterInfoTests
    {
        private const string Name = "Name";
        private const string Description = "Description";

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_NullName_Throws()
        {
            new ParameterInfo(null, Description);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_EmptyName_Throws()
        {
            new ParameterInfo(string.Empty, Description);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesName_Throws()
        {
            new ParameterInfo("   ", Description);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_NullDescription_Throws()
        {
            new ParameterInfo(Name, null);
        }
        
        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_EmptyDescription_Throws()
        {
            new ParameterInfo(Name, string.Empty);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesDescription_Throws()
        {
            new ParameterInfo(Name, "   ");
        }

        [Test]
        public void Clone_ReferencesTest_NotEqual()
        {
            var parameterInfo = new ParameterInfo(Name, Description);
            var clone = parameterInfo.Clone();

            Assert.IsFalse(ReferenceEquals(parameterInfo, clone));
        }

        [Test]
        public void Clone_ContentTest_Equal()
        {
            var parameterInfo = new ParameterInfo(Name, Description);
            var clone = parameterInfo.Clone() as ParameterInfo;

            Assert.AreEqual(parameterInfo.Name, clone.Name);
            Assert.AreEqual(parameterInfo.Description, clone.Description);
        }
    }
}
