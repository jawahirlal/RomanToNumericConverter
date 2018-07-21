# RomanToNumericConverter
Convert roman number to numeric number

## The solution converts the roman number to its respective numeric value. To find out more about roman values please visit: https://en.wikipedia.org/wiki/Roman_numerals

To implement the solution, I have used the fact that Roman numbers have got a defined order. Which is defined as:

```
private const string romanValuesInOrder = "MDCLXVI";
```

If the values are in order from left to right the we should keep adding the values and substract otherwise e.g. XVI

The individual digits:
```
X
V
I

are defined in order from left to right as per: MDCLXVI
```

### If the digit is defined on the left from the above defined order then we should substract the values e.g. IV

I is on the left of V which is not as per the defiend order. Therefore, 5-1 = 4

## Sample Code
```
private const string romanValuesInOrder = "MDCLXVI";
        private const char charDefault = char.MinValue;

        public int getNumeric(string romanNumber)
        {
            var romatDigits = romanNumber.ToCharArray();
            var total = 0;
            var prevDigit = charDefault;
            var prevDigitValue = 0;
            foreach (var digit in romatDigits)
            {
                var currentDigitValue = getValue(digit);

                if (prevDigit != charDefault && romanValuesInOrder.IndexOf(digit) < romanValuesInOrder.IndexOf(prevDigit))
                {
                    currentDigitValue -= (prevDigitValue * 2);
                }

                total += currentDigitValue;

                prevDigit = digit;
                prevDigitValue = currentDigitValue;
            }

            return total;
        }

        private int getValue(char romanDigit)
        {

            switch (romanDigit)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    throw new KeyNotFoundException($"Unable to find mapping for roman digit {romanDigit}.");

            }
            
        }
   
```
## Similarly, some tests are:

```
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