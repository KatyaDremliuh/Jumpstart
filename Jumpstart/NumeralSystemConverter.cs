using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Jumpstart
{
    /* Task_03.
     * Написать программу, принимающую из командной строки целое число в десятичной системе,
     * и основание новой системы счисления (от 2 до 20),
     * вывести в консоль преобразованное в эту систему исходное число.
     */

    class NumeralSystemConverter
    {
        private const string ErrorMessage1 = "\tThe radix is invalid.";
        private const string ErrorMessage2 = "\tA decimal number to convert should be more than the new base.";
        private const string NewBaseEqualsSourceNumber = "10";

        public static void PrintResult()
        {
            string convertToBase = ConvertFromDecimalToBase();

            Console.WriteLine(convertToBase.Equals(ErrorMessage1)
                ? ErrorMessage1
                : $"\tThe result is: {convertToBase}.\n");
        }

        private static string ConvertFromDecimalToBase()
        {
            int decimalNumber = InputNumber("\tInput a decimal number to convert: ");
            int radix = InputNumber("\tInput the number base to convert to: ");

            string result;

            if (Math.Abs(decimalNumber) < radix)
            {
                return ErrorMessage2;
            }

            if (radix < 2 || radix > 20)
            {
                return ErrorMessage1;
            }

            if (decimalNumber == radix)
            {
                result = NewBaseEqualsSourceNumber;
                return result;
            }

            bool isNegative = false;

            if (decimalNumber < 0)
            {
                isNegative = true;
            }

            result = radix <= 9
               ? GetUpTo9(GetDigits((uint)decimalNumber, (uint)radix))
               : GetHex((uint)decimalNumber, (uint)radix);

            if (!isNegative)
            {
                return result;
            }

            return result;
        }
        
        private static string GetHex(uint decimalNumber, uint radix)
        {
            StringBuilder stringBuilder = new StringBuilder();

            List<int> results = GetDigits(decimalNumber, radix);

            foreach (var num in results)
            {
                string hexDigit = num switch
                {
                    10 => "A",
                    11 => "B",
                    12 => "C",
                    13 => "D",
                    14 => "E",
                    15 => "F",
                    16 => "G",
                    17 => "H",
                    18 => "I",
                    19 => "J",
                    _ => num.ToString("D", CultureInfo.InvariantCulture)
                };

                stringBuilder.Append(hexDigit);
            }

            return stringBuilder.ToString().ToUpperInvariant();
        }

        private static List<int> GetDigits(uint decimalNumber, uint radix)
        {
            List<int> digits = new List<int>();
            uint reminder = decimalNumber;

            while (reminder >= radix)
            {
                digits.Add((int)(reminder % radix));
                reminder /= radix;
            }

            digits.Add((int)reminder);
            digits.Reverse();

            return digits;
        }

        private static string GetUpTo9(List<int> number)
        {
            return string.Join(string.Empty, number);
        }

        private static int InputNumber(string message)
        {
            Console.Write(message);
            int number = 0;

            while (true)
            {
                try
                {
                    string numberString = Console.ReadLine();

                    if (numberString != null)
                    {
                        number = int.Parse(numberString);
                    }

                    break;
                }
                catch (Exception)
                {
                    Console.Write("Try again. Input only a number: ");
                }
            }

            return number;
        }
    }
}
