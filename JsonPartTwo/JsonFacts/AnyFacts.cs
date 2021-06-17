using Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonFacts
{
    public class AnyFacts
    {
        [Fact]
        public void NullTextReturnFalse()
        {
            var a = new Any("aA");
            Assert.False(a.Match(null).Success());
        }

        [Fact]
        public void EmptyTextReturnFalse()
        {
            var a = new Any("aA");
            Assert.False(a.Match("").Success());
        }

        [Fact]
        public void TextMatch()
        {
            var a = new Any("aA");
            Assert.True(a.Match("abcd").Success());
            Assert.Equal("bcd", a.Match("abcd").RemainingText());
        }

        [Fact]
        public void SignsMatch()
        {
            var sign = new Any("+-");
            Assert.True(sign.Match("+3").Success());
            Assert.True(sign.Match("-2").Success());
            Assert.Equal("3", sign.Match("+3").RemainingText());
            Assert.Equal("2", sign.Match("-2").RemainingText());


        }
    }
}
