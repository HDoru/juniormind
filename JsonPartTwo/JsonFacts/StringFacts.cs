using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Json;
using String = Json.String;

namespace JsonFacts
{
    public class StringFacts
    {
        [Fact]
        public void IsWrappedInDoubleQuotes()
        {
            var word = new Json.String(); 
            Assert.True(word.Match(Quoted("abc")).Success());
            Assert.Equal("", word.Match(Quoted("abc")).RemainingText());
        }

       [Fact]
        public void AlwaysStartsWithQuotes()
        {
            String word = new Json.String();
            Assert.False(word.Match("abc\"").Success());
        }

        [Fact]
        public void AlwaysEndsWithQuotes()
        {
            String word = new Json.String();
            Assert.False(word.Match("\"abc").Success());
         
        }

        [Fact]
        public void IsNotNull()
        {
            String word = new Json.String();
            Assert.False(word.Match(null).Success());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            String word = new Json.String();
            Assert.False(word.Match(string.Empty).Success());
        }

        [Fact]
        public void IsAnEmptyDoubleQuotedString()
        {
            String word = new Json.String();
            Assert.True(word.Match(Quoted(string.Empty)).Success());
            Assert.Equal("", word.Match(Quoted(string.Empty)).RemainingText());
           
        }

        [Fact]
        public void HasStartAndEndQuotes()
        {
            String word = new Json.String();
            Assert.False(word.Match("\"").Success());
            
        }

 /*
        [Fact]
        public void DoesNotContainControlCharacters()
        {
            Assert.False(IsJsonString(Quoted("a\nb\rc")));
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            Assert.True(IsJsonString(Quoted("⛅⚾")));
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            Assert.True(IsJsonString(Quoted(@"\""a\"" b")));
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            Assert.True(IsJsonString(Quoted(@"a \\ b")));
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            Assert.True(IsJsonString(Quoted(@"a \/ b")));
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            Assert.True(IsJsonString(Quoted(@"a \b b")));
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            Assert.True(IsJsonString(Quoted(@"a \f b")));
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            Assert.True(IsJsonString(Quoted(@"a \n b")));
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            Assert.True(IsJsonString(Quoted(@"a \r b")));
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            Assert.True(IsJsonString(Quoted(@"a \t b")));
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            Assert.True(IsJsonString(Quoted(@"a \u26Be b")));
        }

        [Fact]
        public void DoesNotContainUnrecognizedExcapceCharacters()
        {
            Assert.False(IsJsonString(Quoted(@"a\x")));
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            Assert.False(IsJsonString(Quoted(@"a\")));
        }

        [Fact]
        public void DoesNotEndWithAnUnfinishedHexNumber()
        {
            Assert.False(IsJsonString(Quoted(@"a\u")));
            Assert.False(IsJsonString(Quoted(@"a\u123")));
        }
*/
 
        public static string Quoted(string text)
            => $"\"{text}\"";
    }
       
}
