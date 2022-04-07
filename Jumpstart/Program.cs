using System;
using Jumpstart.SkyItems;
using Jumpstart.VehicleFleet;

namespace Jumpstart
{
    public static class Program
    {
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";
        private const int CommandHelpIndex = 0;
        private const int DescriptionHelpIndex = 1;
        private const int ExplanationHelpIndex = 2;
        private static bool isRunning = true;

        private static Tuple<string, Action<string>>[] commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("help", PrintHelp),
            new Tuple<string, Action<string>>("exit", Exit),
            new Tuple<string, Action<string>>("description", ShowProgramDescription),

            new Tuple<string, Action<string>>("1",UniqueSigns.CountUniqueSigns),
            new Tuple<string, Action<string>>("2",NumeralSystemConverter.ConvertNumber),
            new Tuple<string, Action<string>>("4", ControlOfTheSkyItems.CreateSkyItems),

            new Tuple<string, Action<string>>("stat",RunVehicleFleet.Stat),
            new Tuple<string, Action<string>>("create", RunVehicleFleet.Create),
            new Tuple<string, Action<string>>("list", RunVehicleFleet.List),
            new Tuple<string, Action<string>>("update", RunVehicleFleet.UpdateAuto),
            new Tuple<string, Action<string>>("find", RunVehicleFleet.GetAutoByParameter),
            new Tuple<string, Action<string>>("remove", RunVehicleFleet.RemoveAuto),
        };

        private static string[][] helpMessages = new string[][]
        {
            new string[] { "help", "prints the help screen", "The 'help' command prints the help screen.",},
            new string[] { "exit", "exits the application", "The 'exit' command exits the application.", },
            new string[] { "description", "shows description for each program/command", },

            new string[] { "1", "shows the length of the longest sequence with non-repetitive signs.", },
            new string[] { "2", "converts from decimal.", },
            new string[] { "4", "shows items that can fly.", },

            new string[] { "stat", "display number of records", "The 'stat' command displays number of records.", },
            new string[] { "create", "create data on a vehicle", "The 'create' command creates data on a vehicle.", },
            new string[] { "list", "return a list of entries that were added to the service", "The 'list' command returns a list of entries that were added to the service.", },
            new string[] { "update", "update a record", "The 'update' updates a record.",},
            new string[] { "find", "find records by given parameters", "The 'find' finds records by given parameters.", },
        };

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine(Program.HintMessage);
            Console.WriteLine();

            do
            {
                Console.Write("> ");
                var inputs = Console.ReadLine().Split(' ', 2);
                const int commandIndex = 0;
                var command = inputs[commandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(Program.HintMessage);
                    continue;
                }

                var index = Array.FindIndex(commands, 0, commands.Length, i
                    => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    const int parametersIndex = 1;
                    var parameters = inputs.Length > 1 ? inputs[parametersIndex] : string.Empty;
                    commands[index].Item2(parameters);
                }
                else
                {
                    PrintMissedCommandInfo(command);
                }
            }
            while (isRunning);
        }

        private static void PrintMissedCommandInfo(string command)
        {
            Console.WriteLine($"There is no '{command}' command.");
            Console.WriteLine();
        }

        private static void PrintHelp(string parameters)
        {
            if (!string.IsNullOrEmpty(parameters))
            {
                var index = Array.FindIndex(helpMessages, 0, helpMessages.Length, i
                    => string.Equals(i[Program.CommandHelpIndex], parameters, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    Console.WriteLine(helpMessages[index][Program.ExplanationHelpIndex]);
                }
                else
                {
                    Console.WriteLine($"There is no explanation for '{parameters}' command.");
                }
            }
            else
            {
                Console.WriteLine("Available commands:");

                foreach (var helpMessage in helpMessages)
                {
                    Console.WriteLine("\t{0}\t- {1}", helpMessage[Program.CommandHelpIndex], helpMessage[Program.DescriptionHelpIndex]);
                }
            }

            Console.WriteLine();
        }

        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            isRunning = false;
        }

        private static void ShowProgramDescription(string command)
        {
            string sequenceDescription = ("\tThe 1-st program shows the length of the longest sequence with non-repetitive signs.\n");

            string numericalSystemConverterDescription = "\tThe 2-nd program converts a decimal numerical system to any numerical system from 2 to 20.\n";

            string flyingProgramDescription = "\tThe 4-th program creates items that can fly and shows the following positions:" +
                 "\n\t- the start and the finish coordinates;" +
                 "\n\t- time spent to fly from the start point to destination point;" +
                 "\n\t- flying speed;" +
                 "\n\t- distance.\n";

            string vehicleCommandsDescription = "commands \"stat\", \"create\", \"list\", \"update\", \"find\" are used for creating vehicle fleet.";

            string[] description = { sequenceDescription, numericalSystemConverterDescription, flyingProgramDescription, vehicleCommandsDescription, };

            for (int i = 0; i < description.Length; i++)
            {
                if (i % 2 == 0)
                {
                    ServiceInformation.ColorMessage(description[i], ConsoleColor.DarkYellow);

                }
                else
                {
                    ServiceInformation.ColorMessage(description[i], ConsoleColor.Green);

                }
            }
        }
    }
}