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
        public void NullTextShouldReturnFalse()
        {
            Character x = new Character('x');
            Assert.False(x.Match("xav").Success());
        }
    }
}
