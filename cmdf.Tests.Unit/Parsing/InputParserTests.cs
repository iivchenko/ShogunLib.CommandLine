// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using CommandLineInterpreterFramework.Parsing;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Parsing
{
    [TestFixture]
    public class InputParserTests
    {
        // TODO: Finish 
        // Parse_ValidInput_ReturnsCorrectParsedCommand
        private InputParser _inputParser;

        [SetUp]
        public void Setup()
        {
            _inputParser = new InputParser();
        }

        [TestCase("Command")]
        [TestCase("Command arg1")]
        [TestCase(" Command arg1  arg2 ")]
        [TestCase("Command \"hello man\" arg1 \"how are you\" \\\"")]
        public void Parse_ValidInput_ReturnsParsedCommand(string input)
        {
            var parsedCommand = _inputParser.Parse(input);

            Assert.IsNotNull(parsedCommand);
        }

        [TestCase("")]
        [TestCase("CommandName \"incorrect number of double quotes")]
        [TestCase("CommandName \"incorrect number of double quotes \"\"")]
        [ExpectedException(typeof(InputParserException))]
        public void Parse_InvalidInput_Throws(string input)
        {
            _inputParser.Parse(input);
        }
    }
}
