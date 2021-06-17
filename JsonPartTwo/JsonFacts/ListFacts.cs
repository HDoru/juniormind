using Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Range = Json.Range;

namespace JsonFacts
{
    public class ListFacts
    {
        [Fact]
        public void NullTextReturnTrue()
        {
            List list = new List(new Character('a'), new Character('b'));
            Assert.True(list.Match(null).Success());
        }

        [Fact]
        public void EmptyTextReturnTrue()
        {
            List l = new List(new Range('0', '9'), new Character('x'));
            Assert.Empty(l.Match("").RemainingText());
        }

        [Fact]
        public void ListMatch()
        {
            List l = new List(new Range('0', '9'), new Character(','));
            Assert.True(l.Match("1,2,3").Success());
            Assert.Equal("", l.Match("1,2,3").RemainingText());
        }

        [Fact]
        public void AllListMatch()
        {
            List l = new List(new Range('0', '9'), new Range('a', 'z'));
            Assert.True(l.Match("1a2b3c4").Success());
            Assert.Equal("", l.Match("1a2b3c4").RemainingText());
        }

        [Fact]
        public void ListStartsWithSeparator()
        {
            List x = new List(new Range('0', '9'), new Character(','));
            Assert.Equal(",1,2,3,4,", x.Match(",1,2,3,4,").RemainingText());
        }

        [Fact]
        public void List()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").Success());
            Assert.Equal("", list.Match("1; 22  ;\n 333 \t; 22").RemainingText());

            Assert.True(list.Match("1 \n;").Success());
            Assert.Equal(" \n;", list.Match("1 \n;").RemainingText());

            Assert.True(list.Match("abc").Success());
            Assert.Equal("abc", list.Match("abc").RemainingText());
        }
    }
}
