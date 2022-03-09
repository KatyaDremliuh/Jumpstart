using System.Text;

namespace Jumpstart
{
    class NumeralSystemConverter
    {
        /*
         * Task_02.
         * Написать программу, принимающую из командной строки целое число в десятичной системе,
         * и основание новой системы счисления (от 2 до 20),
         * вывести в консоль преобразованное в эту систему исходное число.
         */

        public string ParsePositiveFromDecimal(int source, int radix)
        {
            StringBuilder newNumber = new StringBuilder();

            while (source > radix)
            {
                int resultOfDivision = source / radix;
                int remainder = source - resultOfDivision * radix;

                if (remainder > 9)
                {
                   char remainderLetter = GetNumericValueForLetter(remainder);
                   newNumber.Append(remainderLetter);
                }
                else
                {
                    newNumber.Append(remainder);
                }
                
                source = resultOfDivision;
            }

            newNumber.Append(source);

            return ReverseString(newNumber.ToString());
        }

        private char GetNumericValueForLetter(int number)
        {
            return number switch
            {
                10 => 'A',
                11 => 'B',
                12 => 'C',
                13 => 'D',
                14 => 'E',
                15 => 'F',
                16 => 'G',
                17 => 'H',
                18 => 'I',
                19 => 'J',
                _ => ' '
            };
        }

        private string ReverseString(string directText)
        {
            StringBuilder reverseText = new StringBuilder();

            for (int i = directText.Length - 1; i >= 0; i--)
            {
                reverseText.Append(directText[i]);
                //newtext += text[i];
            }

            return reverseText.ToString();
        }
    }
}
