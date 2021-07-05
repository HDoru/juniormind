﻿using System;
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


        [Fact]
        public void DoesNotContainControlCharacters()
        {
            String word = new Json.String();
            Assert.False(word.Match(Quoted("a\nb\rc")).Success());
        }
 
        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            String word = new Json.String();
            Assert.True(word.Match(Quoted("⛅⚾")).Success());
        }

        [Fact]
        public void CanContainEscapedQuotationMark()
        {
            String word = new Json.String();
            Assert.True(word.Match(Quoted(@"\""a\"" b")).Success());
          //  Assert.Equal(Quoted(""),word.Match(Quoted(@"\""a\"" b")).RemainingText());
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            String word = new Json.String();
            Assert.True(word.Match(Quoted(@"a \\ b")).Success());
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            String word = new Json.String();
            Assert.True(word.Match(Quoted(@"a \/ b")).Success());
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            String word = new Json.String();
            Assert.True(word.Match(Quoted(@"a \b b")).Success());
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            String word = new Json.String();
            Assert.True(word.Match(Quoted(@"a \f b")).Success());
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            String word = new Json.String();
            Assert.True(word.Match(Quoted(@"a \n b")).Success());
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            String word = new Json.String();
            Assert.True(word.Match(Quoted(@"a \r b")).Success());
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            String word = new Json.String();
            Assert.True(word.Match(Quoted(@"a \t b")).Success());
        }
/*
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
