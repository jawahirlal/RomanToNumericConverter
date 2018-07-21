using System.Collections.Generic;
using Xunit;

namespace RomanToNumeric.Service.Tests
{
    public class RomanToNumericTests
    {
        IRomanToNumeric romanToNumeric;
        public RomanToNumericTests()
        {
            romanToNumeric = new RomanToNumeric();
        }
        [Fact]
        public void WhenPassedValue_I_Returns_1()
        {
            var roman = "I";
            var expected = 1;

            testRomanValue(roman, expected);

        }

        [Fact]
        public void WhenPassedValue_II_Returns_2()
        {
            var roman = "II";
            var expected = 2;

            testRomanValue(roman, expected);
        }


        [Fact]
        public void WhenPassedValue_III_Returns_3()
        {
            var roman = "III";
            var expected = 3;

            testRomanValue(roman, expected);
        }

        [Fact]
        public void WhenPassedValue_IV_Returns_4()
        {
            var roman = "IV";
            var expected = 4;

            testRomanValue(roman, expected);
        }

        [Fact]
        public void WhenPassedValue_VI_Returns_6()
        {
            var roman = "VI";
            var expected = 6;

            testRomanValue(roman, expected);
        }


        [Fact]
        public void WhenPassedValue_VII_Returns_7()
        {
            var roman = "VII";
            var expected = 7;

            testRomanValue(roman, expected);
        }

        [Fact]
        public void multipleTests()
        {
            testRomanValue("IX", 9);
            testRomanValue("X", 10);
            testRomanValue("MDCCLXXVI", 1776);
            testRomanValue("MCMXC", 1990);
            testRomanValue("MMXIV", 2014);
        }

        [Fact]
        public void WhenPassedInvalidRomanDigitThrowsException()
        {
            var throwsException = false;
            try
            {
                testRomanValue("XIA", 9);
            }
            catch (KeyNotFoundException)
            {
                throwsException = true;
            }

            Assert.True(throwsException);
        }

        private void testRomanValue(string romanValue, int expected)
        {
            var result = romanToNumeric.getNumeric(romanValue);

            Assert.Equal(expected, result);
        }
    }
}
