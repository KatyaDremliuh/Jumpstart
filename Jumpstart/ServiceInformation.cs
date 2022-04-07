using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jumpstart
{
    public class ServiceInformation
    {
        public static string ColorMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{message}");
            Console.ResetColor();

            return "";
        }

        public static void ColorMessage1(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"{message}");
            Console.ResetColor();
        }
    }
}