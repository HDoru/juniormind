using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Json;

namespace JsonFacts
{
    public class NumberFacts
    {
        [Fact]
        public void CanBeZero()
        {
            Number number = new Number();
            Assert.True(number.Match("0").Success());
        }

        [Fact]
        public void DoesNotContainLetters()
        {
            Number number = new Number();
            Assert.False(number.Match("a").Success());
        }

        [Fact]
        public void CanHaveASingleDigit()
        {
            Number number = new Number();
            Assert.True(number.Match("7").Success());
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            Number number = new Number();
            Assert.True(number.Match("70").Success());
        }

        [Fact]
        public void IsNotNull()
        {
            Number number = new Number();
            Assert.False(number.Match(null).Success());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            Number number = new Number();
            Assert.False(number.Match(string.Empty).Success());
        }

        [Fact]
        public void DoesNotStartWithZero()
        {
            Number number = new Number();
            Assert.True(number.Match("07").Success());
            Assert.Equal("7", number.Match("07").RemainingText());

        }

        [Fact]
        public void CanBeNegative()
        {
            Number number = new Number();
            Assert.True(number.Match("-26").Success());
        }

        [Fact]
        public void CanBeMinusZero()
        {
            Number number = new Number();
            Assert.True(number.Match("-0").Success());
        }

        [Fact]
        public void CanBeFractional()
        {
            Number number = new Number();
            Assert.True(number.Match("12.34").Success());
        }

        [Fact]
        public void TheFractionCanHaveLeadingZeros()
        {
            Number number = new Number();
            Assert.True(number.Match("0.00000001").Success());
            Assert.True(number.Match("10.00000001").Success());
        }

        [Fact]
        public void DoesNotEndWithADot()
        {
            Number number = new Number();
            Assert.True(number.Match("12.").Success());
            Assert.Equal(".", number.Match("12.").RemainingText());

        }

        [Fact]
        public void DoesNotHaveTwoFractionParts()
        {
            Number number = new Number();
            Assert.True(number.Match("12.34.56").Success());
            Assert.Equal(".56", number.Match("12.34.56").RemainingText());
        }

        [Fact]
        public void TheDecimalPartDoesNotAllowLetters()
        {
            Number number = new Number();
            Assert.True(number.Match("12.3x").Success());
            Assert.Equal("x", number.Match("12.3x").RemainingText());
        }

        [Fact]
        public void CanHaveAnExponent()
        {
            Number number = new Number();
            Assert.True(number.Match("12e3").Success());
        }

        [Fact]
        public void TheExponentCanStartWithCapitalE()
        {
            Number number = new Number();
            Assert.True(number.Match("12E3").Success());
        }

        [Fact]
        public void TheExponentCanHavePositive()
        {
            Number number = new Number();
            Assert.True(number.Match("12e+3").Success());
        }

        [Fact]
        public void TheExponentCanBeNegative()
        {
            Number number = new Number();
            Assert.True(number.Match("61e-9").Success());
        }

        [Fact]
        public void CanHaveFractionAndExponent()
        {
            
            Number number = new Number();
            Assert.True(number.Match("12.34E3").Success());
        }

        [Fact]
        public void TheExponentDoesNotAllowLetters()
        {
            Number number = new Number();
            Assert.True(number.Match("22e3x3").Success());
            Assert.Equal("x3", number.Match("22e3x3").RemainingText());
        }

        [Fact]
        public void DoesNotHaveTwoExponents()
        {
            Number number = new Number();
            Assert.True(number.Match("22e323e33").Success());
            Assert.Equal("e33", number.Match("22e323e33").RemainingText());
        }

        [Fact]
        public void TheExponentIsAlwaysComplete()
        {
                Number number = new Number();
            Assert.True(number.Match("22e").Success());
            Assert.Equal("e", number.Match("22e").RemainingText());
            Assert.True(number.Match("22+").Success());
            Assert.Equal("+", number.Match("22+").RemainingText());
            Assert.True(number.Match("22-").Success());
            Assert.Equal("-", number.Match("22-").RemainingText());

        }

        [Fact]
        public void TheExponentIsAfterTheFraction()
        {
            Number number = new Number();
            Assert.True(number.Match("22e3.3").Success());
            Assert.Equal(".3", number.Match("22e3.3").RemainingText());

        }
    }
}
