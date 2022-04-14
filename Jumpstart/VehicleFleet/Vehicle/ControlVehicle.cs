﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Jumpstart.VehicleFleet.TechnicalSpecs;

namespace Jumpstart.VehicleFleet.Vehicle
{
    public class ControlVehicle
    {
        private readonly List<VehicleRecord> _listWithAllCars = new List<VehicleRecord>();
        private readonly Dictionary<string, VehicleRecord> _engineVinDictionary = new Dictionary<string, VehicleRecord>();

        public int CreateRecord(VehicleRecord record)
        {
            // Создать запись. Поместить ее в список и в словарь (ключ словаря - винНомер мотора)
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
        public void UpdateRecord(int recordId)
        {
            VehicleRecord toUpdate = this._listWithAllCars.Find(car => car.Id == recordId);

            if (toUpdate == null)
            {
                throw new ArgumentException($"Record #{recordId} is not found.");
            }

            toUpdate.Id = recordId;
            toUpdate.CarModel = RunVehicleFleet.GetStringParams("car model");

            switch (toUpdate)
            {
                case Bus bus:
                    UpdateBus(bus);
                    break;

                case PassengerCar car:
                    UpdatePassengerCar(car);
                    break;

                case Truck truck:
                    UpdateTruck(truck);
                    break;

                case Scooter update:
                    UpdateScooter(update);
                    break;
            }

            //UpdateDictionary(toUpdate, _engineVinDictionary, _listWithAllCars, toUpdate.Engine.VinNumber, record.Engine.VinNumber);

            Console.WriteLine($"Record № {toUpdate.Id} was updated.");
        }

        private static void UpdateBus(Bus busToUpdate)
        {
            busToUpdate.Chassis.VinNumber = RunVehicleFleet.GetStringParams("vin chassis");
            busToUpdate.Chassis.SafeLoad = RunVehicleFleet.GetSafeLoadAndPower(10000, 22000, "safe load");
            busToUpdate.Chassis.NumberOfWheel = RunVehicleFleet.GetWheels(4, 8, "number of wheels");

            busToUpdate.Engine.Power = RunVehicleFleet.GetSafeLoadAndPower(120, 700, "power");
            busToUpdate.Engine.Capacity = RunVehicleFleet.GetCapacity(1.8, 14.0, "capacity");
            busToUpdate.Engine.VinNumber = RunVehicleFleet.GetStringParams("vin engine");
            busToUpdate.Engine.Type = RunVehicleFleet.GetEngineType(EngineType.Diesel, "type of engine");

            busToUpdate.Transmission.Vendor = RunVehicleFleet.GetStringParams("vendor");
            busToUpdate.Transmission.NumberOfTransmission = RunVehicleFleet.GetTransmission(4, 12, "number of transmission");
            busToUpdate.Transmission.TransmissionType = RunVehicleFleet.GetTransmissionType(TransmissionType.Mechanical, "type of transmission");

            busToUpdate.NumberOfPassengersSeats = RunVehicleFleet.GetNumberOfPassengersSeats(6, 50, "number of passengers seats");
        }

        private static void UpdatePassengerCar(PassengerCar passengerCarToUpdate)
        {
            passengerCarToUpdate.Chassis.VinNumber = RunVehicleFleet.GetStringParams("vin chassis");
            passengerCarToUpdate.Chassis.SafeLoad = RunVehicleFleet.GetSafeLoadAndPower(1100, 3400, "safe load");
            passengerCarToUpdate.Chassis.NumberOfWheel = RunVehicleFleet.GetWheels(4, 6, "number of wheels");

            passengerCarToUpdate.Engine.Power = RunVehicleFleet.GetSafeLoadAndPower(75, 1000, "power");
            passengerCarToUpdate.Engine.Capacity = RunVehicleFleet.GetCapacity(1.0, 6.5, "capacity");
            passengerCarToUpdate.Engine.VinNumber = RunVehicleFleet.GetStringParams("vin engine");
            passengerCarToUpdate.Engine.Type = RunVehicleFleet.GetEngineType(EngineType.Petrol, "type of engine");

            passengerCarToUpdate.Transmission.Vendor = RunVehicleFleet.GetStringParams("vendor");
            passengerCarToUpdate.Transmission.NumberOfTransmission = RunVehicleFleet.GetTransmission(4, 8, "number of transmission");
            passengerCarToUpdate.Transmission.TransmissionType = RunVehicleFleet.GetTransmissionType(TransmissionType.Automatic, "type of transmission");

            passengerCarToUpdate.BodyType = RunVehicleFleet.GetBodyType(BodyType.Sedan, "body type");
        }

        private static void UpdateTruck(Truck truckToUpdate)
        {
            truckToUpdate.Chassis.VinNumber = RunVehicleFleet.GetStringParams("vin chassis");
            truckToUpdate.Chassis.SafeLoad = RunVehicleFleet.GetSafeLoadAndPower(3000, 35000, "safe load");
            truckToUpdate.Chassis.NumberOfWheel = RunVehicleFleet.GetWheels(4, 18, "number of wheels");

            truckToUpdate.Engine.Power = RunVehicleFleet.GetSafeLoadAndPower(120, 1200, "power");
            truckToUpdate.Engine.Capacity = RunVehicleFleet.GetCapacity(2.0, 14.0, "capacity");
            truckToUpdate.Engine.VinNumber = RunVehicleFleet.GetStringParams("vin engine");
            truckToUpdate.Engine.Type = RunVehicleFleet.GetEngineType(EngineType.Diesel, "type of engine");

            truckToUpdate.Transmission.Vendor = RunVehicleFleet.GetStringParams("vendor");
            truckToUpdate.Transmission.NumberOfTransmission = RunVehicleFleet.GetTransmission(4, 10, "number of transmission");
            truckToUpdate.Transmission.TransmissionType = RunVehicleFleet.GetTransmissionType(TransmissionType.Mechanical, "type of transmission");
        }

        private static void UpdateScooter(Scooter scooterToUpdate)
        {
            scooterToUpdate.Chassis.VinNumber = RunVehicleFleet.GetStringParams("vin chassis");
            scooterToUpdate.Chassis.SafeLoad = RunVehicleFleet.GetSafeLoadAndPower(150, 500, "safe load");
            scooterToUpdate.Chassis.NumberOfWheel = RunVehicleFleet.GetWheelsForScooter(2, 3, "number of wheels");

            scooterToUpdate.Engine.Power = RunVehicleFleet.GetSafeLoadAndPower(7, 50, "power");
            scooterToUpdate.Engine.Capacity = RunVehicleFleet.GetCapacity(0.35, 0.8, "capacity");
            scooterToUpdate.Engine.VinNumber = RunVehicleFleet.GetStringParams("vin engine");
            scooterToUpdate.Engine.Type = RunVehicleFleet.GetEngineType(EngineType.Petrol, "type of engine");

            scooterToUpdate.Transmission.Vendor = RunVehicleFleet.GetStringParams("vendor");
            scooterToUpdate.Transmission.NumberOfTransmission = RunVehicleFleet.GetTransmission(4, 8, "number of transmission");
            scooterToUpdate.Transmission.TransmissionType = RunVehicleFleet.GetTransmissionType(TransmissionType.Automatic, "type of transmission");

            scooterToUpdate.Sidecar = RunVehicleFleet.GetSideCarInfo("car model");
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

            //// и записать в XML
            ////XmlData.WriteCarsWithBigEngineCapacity(bigCapacity);
            //string path =
            //    @"D:\PROJECTS\[Global] Automated Testing Foundations with .NET\Jumpstart\Jumpstart\BigEngineCapacity.xml";

            //foreach (var VARIABLE in bigCapacity.ToArray())
            //{
            //    VehicleRecord.VehicleRecords.Add(VARIABLE);
            //}


            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(VehicleRecord));
            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //{
            //    foreach (var VARIABLE in VehicleRecord.VehicleRecords)
            //    {
            //        xmlSerializer.Serialize(fs, VARIABLE);
            //    }


            //    Console.WriteLine("Object has been serialized");
            //}





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

        private static void FillDictionary(VehicleRecord record, Dictionary<string, VehicleRecord> dictionary, string dictionaryKey)
        {
            if (!dictionary.ContainsKey(dictionaryKey))
            {
                var dictionaryValue = record;
                dictionary.Add(dictionaryKey, dictionaryValue);
            }
        }

        private static void UpdateDictionary(VehicleRecord record, Dictionary<string, VehicleRecord> dictionary, List<VehicleRecord> list, string oldDictionaryKey, string newDictionaryKey)
        {
            // Обновить запись. Если в словаре нету еще ключа (винНомер мотора), то новый вин - это ключ, удалить старую запись по старому ключу.
            // Если есть вин, то это новый ключ, на это место поместить новую запись. И обновить список.
            if (!dictionary.ContainsKey(newDictionaryKey))
            {
                dictionary.Add(key: newDictionaryKey, value: record);
                dictionary.Remove(oldDictionaryKey);
            }
            else
            {
                dictionary.Add(key: oldDictionaryKey, record);
                list.RemoveAt(record.Id);
                list.Add(record);
            }
        }

    }
}