using System;

namespace Jumpstart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task_03.
            NumeralSystemConverter a = new NumeralSystemConverter();
            a.ParsePositiveFromDecimal(123, 16);

            // Task_01.
            UniqueSigns uniqueSigns = new UniqueSigns();

            do
            {
                Console.WriteLine(
                    $"The length of the longest sequence with non-repetitive signs is {uniqueSigns.FindVariousChars()}\n");
            }
            while (!Exit());

            Console.Clear();
            Console.WriteLine("DONE_01!");
        }

        private static bool Exit()
        {
            Console.WriteLine("Exit application?\n\tYES - exit\n\tNO - continue");
            return Console.ReadLine()!.ToUpperInvariant().Equals("YES");
        }

    }
}