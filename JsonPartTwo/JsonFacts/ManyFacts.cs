using Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonFacts
{
    public class ManyFacts
    {
        [Fact]

        public void TextMatch()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("abcd").Success());
            Assert.Equal("bcd", a.Match("abcd").RemainingText());
        }

        [Fact]
        public void MuplipleTextMatch()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("aaaabcd").Success());
            Assert.Equal("bcd", a.Match("aaaabcd").RemainingText());
        }

        [Fact]
        public void TextNotMatchReturnTrue()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("bcd").Success());
            Assert.Equal("bcd", a.Match("bcd").RemainingText());
        }

        [Fact]
        public void TextEmptyReturnTrue()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void TextNullReturnTrue()
        {
            var a = new Many(new Character('a'));
            Assert.True(a.Match(null).Success());
            Assert.Null(a.Match(null).RemainingText()); ;
        }

        [Fact]

        public void IsInRange()
        {
            var digits = new Many(new Json.Range('0', '9'));
            Assert.True(digits.Match("12345ab123").Success());
            Assert.Equal("ab123", digits.Match("12345ab123").RemainingText());

        }


    }
}
