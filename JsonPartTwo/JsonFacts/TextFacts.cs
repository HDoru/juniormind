using Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonFacts
{
    public class TextFacts
    {
        [Fact]
        public void NullTextReturnFalse()
        {
            var truee = new Text("true");
            Assert.False(truee.Match(null).Success());
            Assert.Null(truee.Match(null).RemainingText());
        }

        [Fact]
        public void EmptyTextReturnFalse()
        {
            var truee = new Text("true");
            Assert.False(truee.Match(string.Empty).Success());
            Assert.Empty(truee.Match("").RemainingText());
        }

        [Fact]
        public void EmptyPrefixTextMatchEmpty()
        {
            var empty = new Text("");
            Assert.True(empty.Match("ceva").Success());
            Assert.Equal("ceva", empty.Match("ceva").RemainingText());
        }

        [Fact]
        public void PrefixTextMatch()
        {
            var prefix = new Text("false");
            Assert.True(prefix.Match("falseX").Success());
            Assert.Equal("X", prefix.Match("falseX").RemainingText());
        }

        [Fact]
        public void PrefixTextNotMatch()
        {
            var prefix = new Text("false");
            Assert.False(prefix.Match("Xfalse").Success());
            Assert.Equal("Xfalse", prefix.Match("Xfalse").RemainingText());
        }
    }
}

