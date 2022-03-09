using System;
using System.Collections.Generic;

namespace Jumpstart
{
    class UniqueSigns
    {
        /*
        * Task_01.
        * Написать программу, которая принимает из командной строки последовательность символов (строку)
        * в качестве аргумента и выводит в консоль
        * максимальное количество неодинаковых последовательных символов в строке
        */

        public int FindVariousChars()
        {
            Console.Write("Input a string to count the maximum sequence of non-repetitive signs: ");
            string source = Console.ReadLine();

            switch (source.Length)
            {
                case 1:
                    return 1;
                case 0:
                    return 0;
            }

            int countNonRepetitive = 1;
            int maxNonRepetitive = 0;
            HashSet<int> uniqueChars = new HashSet<int>();

            for (int i = 0; i < source.Length - 1; i++)
            {
                uniqueChars.Add(source[i]);

                if ((source[i] != source[i + 1]) && (!uniqueChars.Contains(source[i + 1])))
                {
                    countNonRepetitive++;
                }
                else
                {
                    if (countNonRepetitive > maxNonRepetitive)
                    {
                        maxNonRepetitive = countNonRepetitive;
                        countNonRepetitive = 1;
                        uniqueChars.Clear();
                    }

                    if (maxNonRepetitive >= source.Length - (i + 1))
                    {
                        break;
                    }
                }
            }

            return maxNonRepetitive >= countNonRepetitive ? maxNonRepetitive : countNonRepetitive;
        }
    }
}