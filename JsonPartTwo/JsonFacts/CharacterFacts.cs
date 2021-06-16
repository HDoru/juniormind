using Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonFacts
{
    public class CharacterFacts
    {

        [Fact]
        public void NullTextReturnFalse()
        {
            Character character = new Character('a');
            Assert.False(character.Match(null).Success());
        }

        [Fact]
        public void EmptyTextReturnFalse()
        {
            Character character = new Character('a');
            Assert.False(character.Match("").Success());
        }

        [Fact]
        public void TextStartsWithSameCharacter()
        {
            Character character = new Character('a');
            Assert.True(character.Match("abc").Success());
        }

        [Fact]
        public void TextStartsNotWithSameCharacter()
        {
            Character character = new Character('b');
            Assert.False(character.Match("abc").Success());
        }

        [Fact]
        public void RemainingTextMatch()
        {
            Character character = new Character('a');
            character.Match("abc").Success();
            Assert.Equal("bc", character.Match("abc").RemainingText());
        }


    }
}
