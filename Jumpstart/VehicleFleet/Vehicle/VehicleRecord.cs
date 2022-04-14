using System;
using Jumpstart.VehicleFleet.TechnicalSpecs;

namespace Jumpstart.VehicleFleet.Vehicle
{
    [Serializable]
    public abstract class VehicleRecord
    {
        public abstract string VehicleType { get; }

        public int Id { get; set; }
        public string CarModel { get; set; }
        public Chassis Chassis { get; set; }
        public Engine Engine { get; set; }
        public Transmission Transmission { get; set; }

        //public static List<VehicleRecord> VehicleRecords = new List<VehicleRecord>();

        /// <summary>
        /// Returns a list of records added to the list as strings.
        /// </summary>
        /// <returns>Records as strings.</returns>
        public override string ToString()
        {
            return $"\tRecord № {Id}.\n\tVehicle type: {VehicleType} **{CarModel}**" +
                                  $"\n---Chassis description---" +
                                  $"\n\tWheel: {Chassis.NumberOfWheel}" +
                                  $"\n\tChassis Vin number: {Chassis.VinNumber}" +
                                  $"\n\tChassis safe load: {Chassis.SafeLoad}" +
                                  $"\n---Engine description---" +
                                  $"\n\tPower: {Engine.Power}" +
                                  $"\n\tCapacity: {Engine.Capacity}" +
                                  $"\n\tEngine type: {Engine.Type}" +
                                  $"\n\tEngine Vin number: {Engine.VinNumber}" +
                                  $"\n---Transmission description---" +
                                  $"\n\tTransmission type: {Transmission.TransmissionType}" +
                                  $"\n\tNumber of transmission: {Transmission.NumberOfTransmission}" +
                                  $"\n\tVendor: {Transmission.Vendor}\n";
        }
    }
}