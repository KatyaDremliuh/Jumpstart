using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Jumpstart.VehicleFleet.TechnicalSpecs;
using Jumpstart.VehicleFleet.Vehicle;

namespace Jumpstart.VehicleFleet
{
    public class RunVehicleFleet
    {
        private static readonly CultureInfo _cultureInfo = CultureInfo.InvariantCulture;
        private static ControlVehicle _controlVehicle = new ControlVehicle(new Bank());

        private List<int> l = new List<int>();

        // CREATE
        public static void Create(string parameters)
        {
            VehicleRecord record = FindOutTypeOfVehicleRecord();

            int recordId = _controlVehicle.CreateRecord(record);
            //XmlData.CreateTS(record);
            //string path =
            //    @"D:\PROJECTS\[Global] Automated Testing Foundations with .NET\Jumpstart\Jumpstart\VehicleFleet\VehiclesWithBigEngineCapacity.xml";

            //var xdoc = XDocument.Load(path);
            //var xelement = new XElement("Vehicle", new XAttribute("id", record.Id), new XElement("Model", record.CarModel));
            //xdoc.Root.Add(xelement);
            //xdoc.Save(path);

            Console.WriteLine($"Record № {recordId} is created.");
        }

        public static void Stat(string parameters)
        {
            int recordsCount = _controlVehicle.GetStat();
            Console.WriteLine($"{recordsCount} record(s).");
        }

        private static VehicleRecord FindOutTypeOfVehicleRecord()
        {
            string typeOfVehicle = GetVehicleType(
                ServiceInformation.ColorMessage(
                    $"\tChoose type of vehicle to create:\n" + $"\n\t1 - Bus;\n\t2 - Passenger car;\n\t3 - Scooter;\n\t4 - Truck.\n",
                    ConsoleColor.Cyan));

            VehicleRecord record = typeOfVehicle switch
            {
                "1" => CreateBus(),
                "2" => CreatePassengerCar(),
                "3" => CreateScooter(),
                "4" => CreateTruck(),
                var _ => null,
            };

            return record;
        }

        private static string GetVehicleType(string message)
        {
            string vehicle;

            do
            {
                Console.Write(message);
                vehicle = Console.ReadLine();

                if (!VerificationParameters.IsValidLength(vehicle) || string.IsNullOrWhiteSpace(vehicle))
                {
                    Console.WriteLine("Write only one symbol: \"1\", \"2\", \"3\" or \"4\"");
                }
            }
            while (!VerificationParameters.IsValidLength(vehicle) || string.IsNullOrWhiteSpace(vehicle));

            return vehicle;
        }

        private static Bus CreateBus()
        {
            Bus bus = new()
            {
                CarModel = GetStringParams("car model"),
                Chassis = new Chassis(GetStringParams("vin chassis"), GetSafeLoadAndPower(10000, 22000, "safe load"), GetWheels(4, 8, "number of wheels")),
                Engine = new Engine(GetSafeLoadAndPower(120, 700, "power"), GetCapacity(1.8, 14.0, "capacity"), GetStringParams("vin engine"), GetEngineType(EngineType.Diesel, "type of engine")),
                Transmission = new Transmission(GetStringParams("vendor"), GetTransmission(4, 12, "number of transmission"), GetTransmissionType(TransmissionType.Mechanical, "type of transmission")),
                NumberOfPassengersSeats = GetNumberOfPassengersSeats(6, 50, "number of passengers seats"),
            };

            return bus;
        }

        private static PassengerCar CreatePassengerCar()
        {
            PassengerCar passengerCar = new()
            {
                CarModel = GetStringParams("car model"),
                Chassis = new(GetStringParams("vin chassis"), GetSafeLoadAndPower(1100, 3400, "safe load"), GetWheels(4, 6, "number of wheels")),
                Engine = new(GetSafeLoadAndPower(75, 1000, "power"), GetCapacity(1.0, 6.5, "capacity"), GetStringParams("vin engine"), GetEngineType(EngineType.Petrol, "type of engine")),
                Transmission = new(GetStringParams("vendor"), GetTransmission(4, 8, "number of transmission"), GetTransmissionType(TransmissionType.Automatic, "type of transmission")),
                BodyType = GetBodyType(BodyType.Sedan, "body type"),
            };

            return passengerCar;
        }

        private static Scooter CreateScooter()
        {
            Scooter scooter = new()
            {
                CarModel = GetStringParams("car model"),
                Chassis = new(GetStringParams("vin chassis"), GetSafeLoadAndPower(150, 500, "safe load"), GetWheelsForScooter(2, 3, "number of wheels")),
                Engine = new(GetSafeLoadAndPower(7, 50, "power"), GetCapacity(0.35, 0.8, "capacity"), GetStringParams("vin engine"), GetEngineType(EngineType.Petrol, "type of engine")),
                Transmission = new(GetStringParams("vendor"), GetTransmission(4, 8, "number of transmission"), GetTransmissionType(TransmissionType.Automatic, "type of transmission")),
                Sidecar = GetSideCarInfo("car model"),
            };

            return scooter;
        }

        private static Truck CreateTruck()
        {
            Truck truck = new()
            {
                CarModel = GetStringParams("car model"),
                Chassis = new(GetStringParams("vin chassis"), GetSafeLoadAndPower(3000, 35000, "safe load"), GetWheels(4, 18, "number of wheels")),
                Engine = new(GetSafeLoadAndPower(120, 1200, "power"), GetCapacity(2.0, 14.0, "capacity"), GetStringParams("vin engine"), GetEngineType(EngineType.Diesel, "type of engine")),
                Transmission = new(GetStringParams("vendor"), GetTransmission(4, 10, "number of transmission"), GetTransmissionType(TransmissionType.Mechanical, "type of transmission")),
            };

            return truck;
        }

        // Заполнить единую коллекцию, содержащую объекты типа "Грузовик", "Легковой автомобиль", "Автобус", "Скутер"
        public static void List(string parameters)
        {
            ReadOnlyCollection<VehicleRecord> listOfRecords = _controlVehicle.GetRecords();
            DisplayFoundPositions(listOfRecords);
        }

        // UPDATE
        public static void UpdateAuto(string parameters)
        {
            ServiceInformation.ColorMessage1($"To update vehicle write id-number of vehicle: ", ConsoleColor.Cyan);
            string id = Console.ReadLine();

            if (!int.TryParse(id, out int recordsIdToUpdate))
            {
                Console.WriteLine($"Query \"{id}\" is invalid, it is not a number.");
                return;
            }

            try
            {
                if (_controlVehicle.GetRecords().FirstOrDefault(x => x.Id == recordsIdToUpdate) == null)
                {
                    throw new UpdateAutoException();
                }
            }

            catch (UpdateAutoException)
            {
                Console.WriteLine($"Record № {recordsIdToUpdate} is not found.");

                return;
            }

            _controlVehicle.UpdateRecord(recordsIdToUpdate);
        }

        // DELETE
        public static void RemoveAuto(string obj)
        {
            ServiceInformation.ColorMessage1($"To delete vehicle write id-number of vehicle: ", ConsoleColor.Cyan);
            string id = Console.ReadLine();

            if (!int.TryParse(id, out int recordsIdToRemove))
            {
                Console.WriteLine($"Query \"{id}\" is invalid, it is not a number.");
                return;
            }

            VehicleRecord recordToRemove;

            try
            {
                recordToRemove = _controlVehicle.GetRecords().FirstOrDefault(x => x.Id == recordsIdToRemove);

                if (recordToRemove == null)
                {
                    throw new RemoveAutoException();
                }
            }
            catch (RemoveAutoException)
            {
                Console.WriteLine($"Record № {recordsIdToRemove} is not found.");
                return;
            }

            _controlVehicle.RemoveRecord(recordToRemove);
        }

        // FIND
        public static void GetAutoByParameter(string parameters)
        {
            const string message = " - To find vehicles by capacity write: \"capacity UrValue\""
                + "\n - To show engine specs for all trucks & buses write: \"trucks&buses\""
                + "\n - To show information for all vehicles grouped by transmission write: \"transmission\"\n";

            ServiceInformation.ColorMessage($"{message}: ", ConsoleColor.Cyan);
            string parameterToSearch = Console.ReadLine();

            try
            {
                string[] query = VerificationParameters.IsValidParameterToFindAuto(parameterToSearch, out bool isValidQuery);

                if (!isValidQuery || query.Length == 0)
                {
                    throw new GetAutoByParameterException("", parameterToSearch);
                }

                string searchParameter = query[0];
                switch (searchParameter.ToLower(_cultureInfo))
                {
                    case "capacity":
                        ReadOnlyCollection<VehicleRecord> searchedByCapacity = _controlVehicle.FindCarsWithBigEngineCapacity(query[1]);
                        DisplayFoundPositions(searchedByCapacity);
                        break;

                    case "trucks&buses":
                        ReadOnlyCollection<VehicleRecord> trucksAndBuses = _controlVehicle.GetTrucksAndBuses();
                        DisplayFoundPositions(trucksAndBuses);
                        break;

                    case "transmission":
                        ReadOnlyCollection<VehicleRecord> groupedByTransmission = _controlVehicle.GetFullInformationGroupedByTransmission();
                        DisplayFoundPositions(groupedByTransmission);
                        break;

                    default:
                        Console.WriteLine("No matching entries.");
                        break;
                }
            }
            catch (GetAutoByParameterException ex)
            {
                Console.WriteLine(ex.ExMessage);
            }
        }

        public static string GetStringParams(string message)
        {
            string name;

            do
            {
                ServiceInformation.ColorMessage1($"Write {message}: ", ConsoleColor.Cyan);
                name = Console.ReadLine();

                if (!VerificationParameters.IsValidName(name) || string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine($"{message} should contains between 2 and 30 symbols.");
                }
            }
            while (!VerificationParameters.IsValidName(name) || string.IsNullOrWhiteSpace(name));

            return name;
        }

        public static ushort GetSafeLoadAndPower(ushort minValue, ushort maxValue, string message)
        {
            ushort value;

            do
            {
                ServiceInformation.ColorMessage1($"Write {message}: ", ConsoleColor.Cyan);

                if (ushort.TryParse(Console.ReadLine(), NumberStyles.Integer, _cultureInfo, out value) && VerificationParameters.IsValidNumber(value, minValue, maxValue))
                {
                    break;
                }

                Console.WriteLine($"{message} is not in the correct format. Enter a value between {minValue} and {maxValue} including it.");
            }
            while (true);

            return value;
        }

        public static byte GetWheels(byte minValue, byte maxValue, string message)
        {
            byte numberOfWheel;

            do
            {
                ServiceInformation.ColorMessage1($"Write {message}: ", ConsoleColor.Cyan);

                if (byte.TryParse(Console.ReadLine(), NumberStyles.Integer, _cultureInfo, out numberOfWheel) && VerificationParameters.IsValidNumber(numberOfWheel, minValue, maxValue) && numberOfWheel % 2 == 0)
                {
                    break;
                }

                Console.WriteLine($"{message} is not in the correct format. Enter aт even-numbered value between {minValue} and {maxValue} including it.");
            }
            while (true);

            return numberOfWheel;
        }

        public static byte GetWheelsForScooter(byte minValue, byte maxValue, string message)
        {
            byte numberOfWheel;

            do
            {
                ServiceInformation.ColorMessage1($"Write {message}: ", ConsoleColor.Cyan);

                if (byte.TryParse(Console.ReadLine(), NumberStyles.Integer, _cultureInfo, out numberOfWheel) && VerificationParameters.IsValidNumber(numberOfWheel, minValue, maxValue))
                {
                    break;
                }

                Console.WriteLine($"{message} is not in the correct format. Enter a value between {minValue} and {maxValue} including it.");
            }
            while (true);

            return numberOfWheel;
        }

        public static byte GetTransmission(byte minValue, byte maxValue, string message)
        {
            byte numberOfTransmission;

            do
            {
                ServiceInformation.ColorMessage1($"Write {message}: ", ConsoleColor.Cyan);

                if (byte.TryParse(Console.ReadLine(), NumberStyles.Integer, _cultureInfo, out numberOfTransmission)
                    && VerificationParameters.IsValidNumber(numberOfTransmission, minValue, maxValue))
                {
                    break;
                }

                Console.WriteLine($"{message} is not in the correct format. Enter a value between {minValue} and {maxValue} including it.");
            }
            while (true);

            return numberOfTransmission;
        }

        public static byte GetNumberOfPassengersSeats(byte minValue, byte maxValue, string message)
        {
            byte numberOfPassengersSeats;

            do
            {
                ServiceInformation.ColorMessage1($"Write {message}: ", ConsoleColor.Cyan);

                if (byte.TryParse(Console.ReadLine(), NumberStyles.Integer, _cultureInfo, out numberOfPassengersSeats)
                    && VerificationParameters.IsValidNumber(numberOfPassengersSeats, minValue, maxValue))
                {
                    break;
                }

                Console.WriteLine($"{message} is not in the correct format. Enter a value between {minValue} and {maxValue} including it.");
            }
            while (true);

            return numberOfPassengersSeats;
        }

        public static double GetCapacity(double minCapacity, double maxCapacity, string message)
        {
            double capacity;

            do
            {
                ServiceInformation.ColorMessage1($"Write {message}: ", ConsoleColor.Cyan);

                if (double.TryParse(Console.ReadLine(), NumberStyles.AllowDecimalPoint, _cultureInfo, out capacity)
                    && VerificationParameters.IsValidNumber(capacity, minCapacity, maxCapacity))
                {
                    break;
                }

                Console.WriteLine($"{message} is not in the correct format. Enter a value between {minCapacity} and {maxCapacity} including it.");
            }
            while (true);

            return capacity;
        }

        public static EngineType GetEngineType(EngineType defaultEngine, string message)
        {
            int engineType;
            char engine = default;

            do
            {
                ServiceInformation.ColorMessage1($"Choose {message}:\n"
                    + $"\n\t0 - Petrol;\t\t2 - Electro;"
                    + $"\n\t1 - Diesel;\t\tD - default.\n", ConsoleColor.Cyan);

                string key = Console.ReadLine();

                if ((int.TryParse(key, out engineType) && (VerificationParameters.IsValidNumber(engineType, 0, 2)))
                    || VerificationParameters.IsDefault(key))
                {
                    break;
                }

                Console.WriteLine($"Write only one symbol: \"0\", \"1\", \"2\" or \"D\".");
            }
            while (true);

            if (VerificationParameters.IsDefault(engine.ToString()))
            {
                return defaultEngine;
            }

            return (EngineType)engineType; ;
        }

        public static TransmissionType GetTransmissionType(TransmissionType defaultTransmission, string message)
        {
            int transmissionType;
            char transmission = default;

            do
            {
                ServiceInformation.ColorMessage1($"Choose {message}:\n"
                    + $"\n\t0 - Mechanical;\t\t3 - Electro-mechanical;"
                    + $"\n\t1 - Hydro-mechanical;\t\t4 - Automatic;"
                    + $"\n\t2 - Hydraulic;\t\tD - default.\n", ConsoleColor.Cyan);

                string key = Console.ReadLine();

                if ((int.TryParse(key, out transmissionType) && (VerificationParameters.IsValidNumber(transmissionType, 0, 4)))
                    || VerificationParameters.IsDefault(key))
                {
                    break;
                }

                Console.WriteLine($"Write only one symbol: \"0\", \"1\", \"2\", \"3\", \"4\" or \"D\".");
            }
            while (true);

            if (VerificationParameters.IsDefault(transmission.ToString()))
            {
                return defaultTransmission;
            }

            return (TransmissionType)transmissionType;
        }

        public static BodyType GetBodyType(BodyType defaultBodyType, string message)
        {
            int bodyType;
            char body = default;

            do
            {
                ServiceInformation.ColorMessage1($"Choose {message} of vehicle to create:\n"
                    + $"\n\t0 - Sedan;\t\t4 - Crossover;"
                    + $"\n\t1 - Station-Wagon;\t\t5 - Coupe;"
                    + $"\n\t2 - Hatchback;\t\t6 - Convertible;"
                    + $"\n\t3 - Minivan;\t\tD - default.\n", ConsoleColor.Cyan);

                string key = Console.ReadLine();

                if (int.TryParse(key, out bodyType) && (VerificationParameters.IsValidNumber(bodyType, 0, 6))
                    || VerificationParameters.IsDefault(key))
                {
                    break;
                }

                Console.WriteLine($"Write only one symbol: \"0\", \"1\", \"2\", \"3\", \"4\", \"5\", \"6\" or \"D\".");
            }
            while (true);

            if (VerificationParameters.IsDefault(body.ToString()))
            {
                return defaultBodyType;
            }

            return (BodyType)bodyType;
        }

        public static bool GetSideCarInfo(string message)
        {
            bool withSideCar;

            do
            {
                ServiceInformation.ColorMessage1($"Choose if scooter has {message}:\n"
                    + $"\n\t0 - without sideCar;\t\t1 - with sideCar.\n", ConsoleColor.Cyan);

                string key = Console.ReadLine();

                if (int.TryParse(key, out int value) && (VerificationParameters.IsValidNumber(value, 0, 1)))
                {
                    withSideCar = value switch
                    {
                        0 => false,
                        1 => true,
                    };

                    break;
                }

                Console.WriteLine($"Write only one symbol: \"0\" or \"1\".");
            }
            while (true);

            return withSideCar;
        }

        private static void DisplayFoundPositions(ReadOnlyCollection<VehicleRecord> result)
        {
            const string line = "  ---------------------------------------------------------------------------------------------------";
            Console.WriteLine(line);

            foreach (var record in result)
            {
                Console.WriteLine(record);
            }

            Console.WriteLine(line);
        }
    }
}