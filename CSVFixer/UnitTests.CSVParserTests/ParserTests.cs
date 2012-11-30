using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSVParser;
using NUnit.Framework;

namespace UnitTests.CSVParserTests
{
    [TestFixture]
    public class ParserTests
    {
        private Parser _parser = new Parser();

        [Test]
        public void TestSimpleParse()
        {
            const string shortCsv = @"""Bob is great"",""Gave us chocolate cake""";
            var parsed = _parser.ParseLine(shortCsv);
            Assert.That(parsed, Is.EqualTo(shortCsv));
        }

        [Test]
        public void TestParseNicknameInnerQuotes()
        {
            const string shortCsv = @"""Bob """"Robert"""" Flanders is great"",""Gave us chocolate cake"","""",""7.2""";
            const string parsedCsv = @"""Bob -Robert- Flanders is great"",""Gave us chocolate cake"","""",""7.2""";
            var parsed = _parser.ParseLine(shortCsv);
            Assert.That(parsed, Is.EqualTo(parsedCsv));
        }

        [Test]
        public void TestParseRandomInnerQuotes()
        {
            const string shortCsv = @"""Bob Robert""""Flanders is great"",""Gave us chocolate cake"","" "", ""7.2""";
            const string parsedCsv = @"""Bob Robert-Flanders is great"",""Gave us chocolate cake"","" "", ""7.2""";
            var parsed = _parser.ParseLine(shortCsv);
            Assert.That(parsed, Is.EqualTo(parsedCsv));
        }

        [Test]
        public void TestParseLeadingNonQuote()
        {
            const string shortCsv = @"   abc  ""Bob Robert""""Flanders is great"",""Gave us chocolate cake"","" "", ""7.2""";
            const string parsedCsv = @"""Bob Robert-Flanders is great"",""Gave us chocolate cake"","" "", ""7.2""";
            var parsed = _parser.ParseLine(shortCsv);
            Assert.That(parsed, Is.EqualTo(parsedCsv));
        }
    }
}
