using Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Range = Json.Range;

namespace JsonFacts
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void LetterMatch()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());

        }

        [Fact]
        public void EmptyTextReturnTrue()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());

        }

        [Fact]
        public void NullTextReturnTrue()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText()); ;

        }
        [Fact]
        public void IsInRangeReturnTrue()
        {
            var a = new Optional(new Range('0','9'));
            Assert.True(a.Match("1ab").Success());
            Assert.Equal("ab", a.Match("1ab").RemainingText());

        }

        [Fact]
        public void AllPatternMatch()
        {
            OneOrMore x = new OneOrMore(new Range('0', '9'));
            var match = x.Match("123");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void PatterDontMatch()
        {
            OneOrMore x = new OneOrMore(new Range('0', '9'));
            Assert.False(x.Match("ab").Success());
            Assert.Equal("ab", x.Match("0ab").RemainingText());
        }
    }
}

