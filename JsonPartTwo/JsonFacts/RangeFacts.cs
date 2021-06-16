using System;
using Json;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonFacts
{
   public class RangeFacts
    {
        [Fact]
        public void NullTextReturnFalse()
        {
            Json.Range range = new Json.Range('a', 'f');
            Assert.False(range.Match(null).Success());
        }

        [Fact]
        public void EmptyTextReturnFalse()
        {
            Json.Range range = new Json.Range('a', 'f');
            Assert.False(range.Match("").Success());
        }

        [Fact]
        public void IsInRangeReturnFalse()
        {
            Json.Range range = new Json.Range('a', 'f');
            Assert.True(range.Match("bcd").Success());
        }

        [Fact]
        public void IsNotInRangeReturnFalse()
        {
            Json.Range range = new Json.Range('a', 'f');
            Assert.False(range.Match("1ab").Success());
        }


    }
}
