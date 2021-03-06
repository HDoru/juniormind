using Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonFacts
{
    public class ValueFacts
    {
        [Fact]
        public void CanBeString()
        {
            var value = new Json.Value();
            var match = value.Match("\"acesta este primul test\"");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }
        [Fact]
        public void CanBeANumber()
        {
            var value = new Value();
            var match = value.Match("74879");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanBeNull()
        {
            var value = new Value();
            var match = value.Match("null");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanBeTrue()
        {
            var value = new Value();
            var match = value.Match("true");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanBeFalse()
        {
            var value = new Value();
            var match = value.Match("false");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanBeObject()
        {
            var value = new Value();
            var match = value.Match("{ \"ceva\" : 10 }");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanBeEmptyObject()
        {
            var value = new Value();
            var match = value.Match("{     }");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanBeArray()
        {
            var value = new Value();
            var match = value.Match("[42,2,40,10,7,9]");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }

        [Fact]
        public void CanBeEmptyArray()
        {
            var value = new Value();
            var match = value.Match("[  ]");
            Assert.True(match.Success());
            Assert.Equal("", match.RemainingText());
        }
    }
}
