using Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Range = Json.Range;

namespace JsonFacts
{
    public class SequenceFacts
    {

        [Fact]
        public void NullTextReturnFalse()
        {
            var ab = new Sequence( new Character('a'),new Character('b'));
            Assert.False(ab.Match(null).Success());
        }

        [Fact]
        public void EmptyTextReturnFalse()
        {
            var ab = new Sequence(new Character('a'), new Character('b'));
            Assert.False(ab.Match("").Success());
        }

        [Fact]
        public void SequenceMatchCharacter()
        {
            Sequence a = new Sequence(new Character('a'));
            Assert.True(a.Match("ayb").Success());
            Assert.Equal("yb", a.Match("ayb").RemainingText());

        }

        [Fact]
        public void SequenceMatchTwoCharacter()
        {
            Sequence ay = new Sequence(new Character('a'), new Character('y'));
            Assert.True(ay.Match("ayb").Success());
            Assert.Equal("b", ay.Match("ayb").RemainingText());

        }

        [Fact]
        public void SequenceNotMatch()
        {
            Sequence ay = new Sequence(new Character('a'), new Character('y'));
            Assert.False(ay.Match("aby").Success());
            Assert.Equal("aby", ay.Match("aby").RemainingText());

        }

        [Fact]
        public void CanContainAnotherSequence()
        {
            var ab = new Sequence( new Character('a'),new Character('b'));
            var abc = new Sequence(ab,new Character('c'));

           
            Assert.True(abc.Match("abc").Success());
            Assert.Equal("", abc.Match("abc").RemainingText());
        }


    }
}
