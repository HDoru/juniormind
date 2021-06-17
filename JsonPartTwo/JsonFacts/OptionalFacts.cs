using Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonFacts
{
    public class OptionalFacts
    {
        [Fact]
        public void NullTextReturnTrue()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match(null).Success());
          
        }

        [Fact]
        public void EmptyTextReturnTrue()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("").Success());
        }

        [Fact]
        public void RemoveMatchPattern()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("abc").Success());
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void RemoveMatchPatterns()
        {
            var a = new Optional(new Character('a'));
            Assert.True(a.Match("aabc").Success());
            Assert.Equal("abc", a.Match("aabc").RemainingText());
        }

        [Fact]
        public void WorksWithsignsReturnTrue()
        {
            var a = new Optional(new Any("-"));
            Assert.True(a.Match("-1").Success());
            Assert.Equal("1", a.Match("-1").RemainingText());
            Assert.True(a.Match("2").Success());
            Assert.Equal("2", a.Match("2").RemainingText());

        }
    }
}
