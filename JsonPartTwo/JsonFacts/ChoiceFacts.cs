using System;
using System.Collections.Generic;
using System.Text;
using Json;
using Xunit;

namespace JsonFacts
{
    public class ChoiceFacts
    {
        [Fact]
        public void NullTextReturnFalse()
        {
            Choice digits = new Choice(new Character('a'), new Json.Range('a', 'd'));
            Assert.False(digits.Match(null).Success());
        }

        [Fact]
        public void EmptyTextReturnFalse()
        {
            Choice digits = new Choice(new Character('a'), new Json.Range('a', 'd'));
            Assert.False(digits.Match("").Success());
        }


        [Fact]
        public void IsInRangeReturnTrue()
        {
            Choice digits = new Choice(new Character('a'), new Json.Range('a', 'f'));
            Assert.True(digits.Match("cd").Success());
        }

        [Fact]
        public void IsCharacterReturnTrue()
        {
            Choice digits = new Choice(new Character('g'), new Json.Range('a', 'f'));
            Assert.True(digits.Match("gd").Success());
        }

   


    }
}
