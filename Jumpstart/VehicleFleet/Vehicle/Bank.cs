using System;
using System.Collections.Generic;

namespace Jumpstart.VehicleFleet.Vehicle
{
    internal class Bank : IHolder

    {
        private readonly List<VehicleRecord> _listWithAllCars = new List<VehicleRecord>();

        private readonly Dictionary<string, VehicleRecord> _allRecords = new Dictionary<string, VehicleRecord>(StringComparer.InvariantCultureIgnoreCase);

        public void AddVehicleToDictionary(VehicleRecord record)
        {
            try
            {
                if (!_allRecords.ContainsKey(record.Engine.VinNumber))
                {
                    _allRecords[record.Engine.VinNumber] = record;
                }
            }
            catch (AddException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UpdateDictionary(VehicleRecord record)
        {
            AddVehicleToDictionary(record);
        }

        public void RemoveVehicleFromDictionary(VehicleRecord record)
        {
            foreach (KeyValuePair<string, VehicleRecord> kvp in _allRecords)
            {
                if (kvp.Value.Engine.VinNumber.Equals(record.Engine.VinNumber))
                {
                    _allRecords.Remove(kvp.Key);
                }
            }


            //var x = _allRecords.Values.Where(record.Id.Equals);
            //if (_allRecords.ContainsValue(x.First()))
            //{
            //    _allRecords.Remove(x.First(x));
            //}


            //VehicleRecord toRemove = this._listWithAllCars.Find(car => car.Id == record.Id);

            //if (toRemove != null)
            //{
            //    this._allRecords.Remove(toRemove);
            //    Console.WriteLine($"Record № {toRemove.Id} was deleted.");
            //}

            Console.WriteLine($"Record № {record.Id} was deleted.");
        }
    }
}