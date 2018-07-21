using System.Collections.Generic;

namespace RomanToNumeric.Service
{
    public class RomanToNumeric : IRomanToNumeric
    {
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
    }
}
