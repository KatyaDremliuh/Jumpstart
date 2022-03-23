using Jumpstart.VehicleFleet.Specs;
using Jumpstart.VehicleFleet.Vehile;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jumpstart
{
    class Menu
    {
        private const string HintMessage = "Enter your command, or enter 'help' to get help.";
        private const int CommandHelpIndex = 0;
        private const int DescriptionHelpIndex = 1;
        private const int ExplanationHelpIndex = 2;
        private static bool _isRunning = true;

        private readonly Tuple<string, Action<string>>[] _commands = new Tuple<string, Action<string>>[]
        {
            new Tuple<string, Action<string>>("help", PrintHelp),
            new Tuple<string, Action<string>>("exit", Exit),
            new Tuple<string, Action<string>>("1", CountUniqueSigns),
            new Tuple<string, Action<string>>("2", ConvertNumber),
            new Tuple<string, Action<string>>("3", CreateVehileFleet),
            new Tuple<string, Action<string>>("4", CreateSkyItems),
            new Tuple<string, Action<string>>("description", ShowProgramDescription)
        };

        private static readonly string[][] HelpMessages = new string[][]
        {
            new string[] { "help", "prints the help screen" },
            new string[] { "exit", "exits the application" },
            new string[] { "1", "shows the length of the longest sequence with non-repetitive signs." },
            new string[] { "2", "converts from decimal." },
            new string[] { "3", "shows specs of cars in the vehile fleet." },
            new string[] { "4", "shows items that can fly." },
            new string[] { "description", "shows rules for each game" }
        };

        public void ShowMenu()
        {
            DisplayAvailableCommands();

            do
            {
                Console.WriteLine(HintMessage);
                Console.Write("> ");
                string[] inputs = Console.ReadLine()?.Split(' ', 2);
                const int commandIndex = 0;
                string command = inputs[commandIndex];

                if (string.IsNullOrEmpty(command))
                {
                    Console.WriteLine(HintMessage);
                    continue;
                }

                int index = Array.FindIndex(_commands, 0, _commands.Length, i
                    => i.Item1.Equals(command, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    const int parametersIndex = 1;
                    string parameters = inputs.Length > 1 ? inputs[parametersIndex] : string.Empty;
                    _commands[index].Item2(parameters);
                }
                else
                {
                    PrintMissedCommandInfo(command);
                }
            }
            while (_isRunning);

            Console.WriteLine(HintMessage);
            Console.WriteLine();
        }

        private static void CountUniqueSigns(string command)
        {
            Console.Clear();
            UniqueSigns uniqueSigns = new UniqueSigns();

            Console.WriteLine(
                $"The length of the longest sequence with non-repetitive signs is:" +
                $" {uniqueSigns.FindVariousChars()}.\n");
        }

        private static void ConvertNumber(string command)
        {
            Console.Clear();

            NumeralSystemConverter converter = new NumeralSystemConverter();
            NumeralSystemConverter.PrintResult();
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
                int index = Array.FindIndex(HelpMessages, 0, HelpMessages.Length, i
                    => string.Equals(i[CommandHelpIndex], parameters, StringComparison.InvariantCultureIgnoreCase));
                if (index >= 0)
                {
                    Console.WriteLine(HelpMessages[index][ExplanationHelpIndex]);
                }
                else
                {
                    Console.WriteLine($"There is no explanation for '{parameters}' command.");
                }
            }
            else
            {
                Console.WriteLine("Available commands:");

                foreach (var helpMessage in HelpMessages)
                {
                    Console.WriteLine("\t{0}\t- {1}", helpMessage[CommandHelpIndex], helpMessage[DescriptionHelpIndex]);
                }
            }

            Console.WriteLine();
        }

        private static void Exit(string parameters)
        {
            Console.WriteLine("Exiting an application...");
            _isRunning = false;
        }

        private static void ShowProgramDescription(string command)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\tThe 1-st program shows the length of the longest sequence with non-repetitive signs.\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tThe 2-nd program converts a decimal number system to any numeral system from 2 to 20.\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\tThe 3-rd program shows specs of cars in the vehile fleet.\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tThe 4-th program creates items that can fly and shows the following positions:" +
                              "\n\t- the start and the finish coordinates;" +
                              "\n\t- time spent to fly from the start point to destination point;" +
                              "\n\t- flying speed;" +
                              "\n\t- distance.\n");
            Console.ResetColor();
        }

        private static void DisplayAvailableCommands()
        {
            Console.WriteLine("Write a suitable command:\n");

            for (int i = 0; i < HelpMessages.Length; i++)
            {
                for (int j = 0; j < HelpMessages[i].Length; j++)
                {
                    Console.Write($"\t * {HelpMessages[i][j],-10}");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void CreateVehileFleet(string command)
        {
            Console.Clear();

            PassengerCar mazdaRx8 = new()
            {
                CarModel = "Mazda RX8",
                Chassis = new Chassis("240/40R18", 1710),
                Engine = new Engine(250, 1.8, "JHLRE4857T7C415490"),
                Transmission = new Transmission("Japan", 6)
            };

            PassengerCar volkswagenScirocco = new()
            {
                CarModel = "Volkswagen Scirocco",
                Chassis = new Chassis("235/45R17", 1716),
                Engine = new Engine(250, 2, "WVWZZZ13Z9V013898"),
                Transmission = new Transmission("Germany", 6)
            };

            PassengerCar hondaInsight = new()
            {
                CarModel = "Honda Insight",
                Chassis = new Chassis("205/65R16", 1654),
                Engine = new Engine(115, 1.6, "JHRWE25568V416434", EngineType.Electro),
                Transmission = new Transmission("Japan", 7, TransmissionType.Automatic)
            };

            PassengerCar opelVectra = new()
            {
                CarModel = "Opel Vectra",
                Chassis = new Chassis("195/60R15", 1850),
                Engine = new Engine(112, 2, "WVRTYT14T9N013856", EngineType.Diesel),
                Transmission = new Transmission("Germany", 3)
            };

            PassengerCar bmw735 = new()
            {
                CarModel = "BMW-735",
                Chassis = new Chassis("280/50R20", 2200),
                Engine = new Engine(245, 3.5, "WNXRFT16T9V043965", EngineType.Diesel),
                Transmission = new Transmission("Germany", 8, TransmissionType.Hydromechanical)
            };

            PassengerCar peugeot308 = new()
            {
                CarModel = "Peugeot-308",
                Chassis = new Chassis("210/55R16", 1900),
                Engine = new Engine(120, 1.6, "VRJDNRI15DIK40322", EngineType.Diesel),
                Transmission = new Transmission("France", 6)
            };

            PassengerCar alfaRomeoStelvio = new()
            {
                CarModel = "Alfa Romeo Stelvio",
                Chassis = new Chassis("240/50R19", 2400),
                Engine = new Engine(210, 2.2, "ZRIFWMR58EMO12957", EngineType.Diesel),
                Transmission = new Transmission("Italy", 8, TransmissionType.Automatic)
            };

            Truck ivecoDaily = new()
            {
                CarModel = "Iveco Daily",
                Chassis = new Chassis("205/60R17", 3300),
                Engine = new Engine(190, 2.3, "ZARTYIN74DFK12937", EngineType.Diesel),
                Transmission = new Transmission("Italy")
            };

            Truck scania124 = new()
            {
                CarModel = "Scania-124",
                Chassis = new Chassis("280/70R22", 18000, 6),
                Engine = new Engine(420, 12, "YSMVVL30MKCU84635", EngineType.Diesel),
                Transmission = new Transmission("Sweden", 6)
            };

            Truck mercedesBenzSprinter316 = new()
            {
                CarModel = "Mercedes-Benz Sprinter-316",
                Chassis = new Chassis("210/60R17", 3400),
                Engine = new Engine(163, 2.2, "WKESDP27000S63943", EngineType.Diesel),
                Transmission = new Transmission("Germany")
            };

            Truck volvoFmx = new()
            {
                CarModel = "Volvo FMX",
                Chassis = new Chassis("385/65R22,5", 32000, 10),
                Engine = new Engine(510, 12, "YWJGFJ130MFI47608", EngineType.Diesel),
                Transmission = new Transmission("Sweden", 8, TransmissionType.Automatic)
            };

            Truck fordTransit = new()
            {
                CarModel = "Ford Transit",
                Chassis = new Chassis("220/55R16", 3200, 6),
                Engine = new Engine(186, 2.2, "A5KDPE139IMM34021", EngineType.Diesel),
                Transmission = new Transmission("USA")
            };

            Bus neoplanN116 = new()
            {
                CarModel = "Neoplan-N116",
                Chassis = new Chassis("270/75R23", 18000, 6),
                Engine = new Engine(380, 12.6, "WMWRC31060TB95535", EngineType.Diesel),
                Transmission = new Transmission("Germany", 12, TransmissionType.Automatic)
            };

            Bus scaniaIrizar = new()
            {
                CarModel = "Scania Irizar",
                Chassis = new Chassis("260/70R22.5", 19000, 6),
                Engine = new Engine(420, 12, "YSWNI349EK2D28726", EngineType.Diesel),
                Transmission = new Transmission("Sweden", 6)
            };

            Bus mercedesBenzSprinter = new()
            {
                CarModel = "Mercedes-Benz Sprinter",
                Chassis = new Chassis("220/50R16", 3460, 6),
                Engine = new Engine(198, 2.2, "WP1AB29P66LA68044", EngineType.Diesel),
                Transmission = new Transmission("Germany", 7, TransmissionType.Automatic)
            };

            Bus citroenJumper = new()
            {
                CarModel = "Citroen Jumper",
                Chassis = new Chassis("205/55R16", 3100),
                Engine = new Engine(175, 2.2, "VFTYN448TY3E22987", EngineType.Diesel),
                Transmission = new Transmission("France")
            };

            Bus renaultMasterL3H2 = new()
            {
                CarModel = "Renault Master-L3H2",
                Chassis = new Chassis("230/50R17", 3300),
                Engine = new Engine(204, 2.3, "VRKLI654F3WE78310", EngineType.Diesel),
                Transmission = new Transmission("France")
            };

            Scooter hondaSh = new()
            {
                CarModel = "Honda-SH",
                Chassis = new Chassis("100/8016M/C", 180, 2),
                Engine = new Engine(16, 1.53, "JT111TJ8007010945"),
                Transmission = new Transmission("Japan", 4)
            };

            Scooter kymcoAgility = new()
            {
                CarModel = "Kymco Agility",
                Chassis = new Chassis("125/5010M/С", 173, 2),
                Engine = new Engine(14, 0.49, "KPTG0B1FS6P213479"),
                Transmission = new Transmission("China", 4, TransmissionType.Automatic)
            };

            Scooter suzukiBurgman = new()
            {
                CarModel = "Suzuki Burgman",
                Chassis = new Chassis("150/7012M/С", 350, 2),
                Engine = new Engine(33, 0.4, "JF1GGGKD37G038841"),
                Transmission = new Transmission("Japan", 4, TransmissionType.Automatic)
            };

            Scooter racherAlphaRc50 = new()
            {
                CarModel = "Racher Alpha-RC50",
                Chassis = new Chassis("70/10017М/С", 180, 2),
                Engine = new Engine(14, 0.5, "KMHBT31GP3U013758"),
                Transmission = new Transmission("China", 4)
            };

            Scooter minskVesna125 = new()
            {
                CarModel = "Minsk Vesna-125",
                Chassis = new Chassis("75/6012М/С", 175, 2),
                Engine = new Engine(8, 0.125, "Y5DIM323IN4R43783"),
                Transmission = new Transmission("Belarus", 4, TransmissionType.Automatic)
            };

            List<Vehicle> auto = new List<Vehicle>
            {
                mazdaRx8,
                volkswagenScirocco,
                hondaInsight,
                opelVectra,
                bmw735,
                peugeot308,
                alfaRomeoStelvio,
                ivecoDaily,
                scania124,
                mercedesBenzSprinter316,
                volvoFmx,
                fordTransit,
                neoplanN116,
                scaniaIrizar,
                mercedesBenzSprinter,
                citroenJumper,
                renaultMasterL3H2,
                hondaSh,
                kymcoAgility,
                suzukiBurgman,
                racherAlphaRc50,
                minskVesna125
            };

            ShowServiceInformation("Cars that have engine capacity more than 1.5 litres:", ConsoleColor.Red);
            GetCarsWithBigEngineCapacity(auto, 1.5);

            ShowServiceInformation("Engine specs for trucks:", ConsoleColor.Yellow);
            GetEngineSpecs(auto, "Truck");

            ShowServiceInformation("Engine specs for buses:", ConsoleColor.Green);
            GetEngineSpecs(auto, "Bus");

            ShowServiceInformation("Full information about all vehiles grouped by transmission:", ConsoleColor.Blue);
            GetFullInformationGroupedByTransmission(auto);
        }

        private static void GetCarsWithBigEngineCapacity(List<Vehicle> auto, double engineCapacity)
        {
            var engineCapacityMore15 = from car in auto
                                       where car.Engine.EngineCapacity > engineCapacity
                                       select car;

            foreach (Vehicle car in engineCapacityMore15)
            {
                car.ShowInfo();
            }
        }

        private static void GetEngineSpecs(List<Vehicle> auto, string vehicleType)
        {
            var engineSpecsForTrucks =
                auto.Where(
                car => car.VehicleType.Equals(vehicleType, StringComparison.Ordinal));
            
            foreach (Vehicle car in engineSpecsForTrucks)
            {
                Console.WriteLine($"{car.VehicleType} **{car.CarModel}**\n" +
                                  $"\tEngine type: {car.Engine.EngineType}\n" +
                                  $"\tEngine Vin number: {car.Engine.VinNumber}\n" +
                                  $"\tEngine power: {car.Engine.Power}\n");
            }
        }

        private static void GetFullInformationGroupedByTransmission(List<Vehicle> auto)
        {
            var carsByTransmission =
                auto.OrderBy(
                    car => car.Transmission.TransmissionType);

            foreach (var car in carsByTransmission)
            {
                car.ShowInfo();
            }
        }

        private static void ShowServiceInformation(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{message}\n");
            Console.ResetColor();
        }

        private static void CreateSkyItems(string command)
        {
            Console.Clear();

            Coordinate destination = new Coordinate(44, 44, 44);

            Bird birdNoWind = new Bird();
            Bird birdWithWind = new Bird(true);
            Drone drone = new Drone(78);
            Plane plane = new Plane();

            List<IFlyable> flyingObjects = new() { birdNoWind, birdWithWind, drone, plane };

            flyingObjects[0].FlyTo(destination);
            foreach (var flyingObject in flyingObjects)
            {
                Console.WriteLine($"----- {RecognizeFlyingObjectType(flyingObject)} -----");
                flyingObject.GetFlyTime(destination);
            }
        }

        private static string RecognizeFlyingObjectType(IFlyable flyingObject)
        {
            string fullName = flyingObject.GetType().ToString();
            return fullName[(fullName.LastIndexOf('.') + 1)..];
        }
    }
}
