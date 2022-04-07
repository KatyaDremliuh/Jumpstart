using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace Jumpstart.VehicleFleet.Vehicle
{
    public class ControlVehicle
    {
        private readonly List<VehicleRecord> _listWithAllCars = new List<VehicleRecord>();
        private readonly Dictionary<string, List<VehicleRecord>> _engineVinDictionary = new Dictionary<string, List<VehicleRecord>>(StringComparer.InvariantCultureIgnoreCase);

        public int CreateRecord(VehicleRecord record)
        {
            try
            {
                if (!this._engineVinDictionary.ContainsKey(key: record.Engine.VinNumber))
                {
                    FillDictionary(record, this._engineVinDictionary, record.Engine.VinNumber); // uniq
                    this._listWithAllCars.Add(record);
                }
                else
                {
                    throw new AddException();
                }
            }
            catch (AddException ex)
            {
                Console.WriteLine(ex.ExMessage);
            }

            record.Id = this._listWithAllCars.Count;

            return record.Id;
        }

        /// <summary>
        /// Edits records. If the record does not exist, the application displays the message "№id record is not found.".
        /// </summary>
        /// <param name="record">Contains edited data in the record.</param>
        public void UpdateRecord(VehicleRecord record)
        {
            VehicleRecord toFind = this._listWithAllCars.Find(car => car.Id == record.Id);

            toFind.CarModel = record.CarModel;
            toFind.Chassis.VinNumber = record.Chassis.VinNumber;
            toFind.Chassis.NumberOfWheel = record.Chassis.NumberOfWheel;
            toFind.Chassis.SafeLoad = record.Chassis.SafeLoad;
            toFind.Engine.Capacity = record.Engine.Capacity;
            toFind.Engine.VinNumber = record.Engine.VinNumber;
            toFind.Engine.Power = record.Engine.Power;
            toFind.Engine.Type = record.Engine.Type;
            toFind.Transmission.NumberOfTransmission = toFind.Transmission.NumberOfTransmission;
            toFind.Transmission.TransmissionType = record.Transmission.TransmissionType;
            toFind.Transmission.Vendor = record.Transmission.Vendor;
        }

        internal ReadOnlyCollection<VehicleRecord> GetRecords()
        {
            return new ReadOnlyCollection<VehicleRecord>(this._listWithAllCars);
        }

        internal int GetStat()
        {
            return this._listWithAllCars.Count;
        }

        public void RemoveRecord(VehicleRecord record)
        {
            VehicleRecord toRemove = this._listWithAllCars.Find(car => car.Id == record.Id);

            if (toRemove != null)
            {
                this._listWithAllCars.Remove(toRemove);
                Console.WriteLine($"Record № {toRemove.Id} was deleted.");
            }
        }

        /// <summary>
        /// Полную информацию о всех транспортных средствах, обьем двигателя которых больше чем 1.5 литров
        /// </summary>
        /// <param name="capacity">То, что ввели для поиска, например, 1.5</param>
        /// <returns></returns>
        internal ReadOnlyCollection<VehicleRecord> FindCarsWithBigEngineCapacity(string capacity)
        {
            var bigCapacity = from car in _listWithAllCars
                              where car.Engine.Capacity > GetCapacity(capacity)
                              select car;

            ServiceInformation.ColorMessage($"Cars that have engine capacity more than {capacity} liters:", ConsoleColor.Red);

            if (bigCapacity.Count() != 0)
            {
                foreach (VehicleRecord car in bigCapacity)
                {
                    Console.WriteLine(car.ToString());
                }
            }
            else
            {
                Console.WriteLine($"The records with capacity more than {capacity} do not exist in the list.");
            }

            // и записать в XML
            XmlData.WriteCarsWithBigEngineCapacity(bigCapacity);

            return new ReadOnlyCollection<VehicleRecord>(new List<VehicleRecord>());
        }

        private static double GetCapacity(string capacityToFind)
        {
            double capacity;

            do
            {
                if (double.TryParse(capacityToFind, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out capacity) && (capacity >= 0))
                {
                    break;
                }

                Console.WriteLine($"Error! Capacity is not in the correct format.");
            }
            while (true);

            return capacity;
        }

        /// <summary>
        /// Тип двигателя, серийный номер и его мощность для всех автобусов и грузовиков
        /// </summary>
        /// <returns></returns>
        internal ReadOnlyCollection<VehicleRecord> GetTrucksAndBuses()
        {
            var engineSpecsForTrucks =
                    _listWithAllCars.Where(
                        car => car.GetType() == typeof(Truck) || car.GetType() == typeof(Bus));

            foreach (VehicleRecord car in engineSpecsForTrucks)
            {
                Console.WriteLine($"{car.VehicleType} **{car.CarModel}**\n" +
                    $"\tEngine type: {car.Engine.Type}\n" +
                    $"\tEngine Vin number: {car.Engine.VinNumber}\n" +
                    $"\tEngine power: {car.Engine.Power}\n");
            }

            return new ReadOnlyCollection<VehicleRecord>(new List<VehicleRecord>());
        }

        /// <summary>
        /// Полную информацию о всех транспортных средствах, сгруппированную по типу трансмиссии.
        /// </summary>
        /// <returns></returns>
        public ReadOnlyCollection<VehicleRecord> GetFullInformationGroupedByTransmission()
        {
            var carsByTransmission =
                _listWithAllCars.OrderBy(
                    car => car.Transmission.TransmissionType);

            ServiceInformation.ColorMessage("Cars that have engine capacity more than 1.5 liters:", ConsoleColor.Red);

            if (carsByTransmission.Count() != 0)
            {
                foreach (VehicleRecord car in carsByTransmission)
                {
                    Console.WriteLine(car.ToString());
                }
            }
            else
            {
                Console.WriteLine($"There are no records in the list.");
            }

            return new ReadOnlyCollection<VehicleRecord>(new List<VehicleRecord>());
        }

        private static void FillDictionary(VehicleRecord record, Dictionary<string, List<VehicleRecord>> dictionary, string key)
        {
            if (!dictionary.ContainsKey(key))
            {
                var value = new List<VehicleRecord>() { record };
                dictionary.Add(key, value);
            }
            else
            {
                dictionary[key].Add(record);
            }
        }
    }
}