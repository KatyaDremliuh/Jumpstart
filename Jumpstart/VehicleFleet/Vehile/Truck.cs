using System;

namespace Jumpstart.VehicleFleet.Vehile
{
    class Truck : Vehicle
    {
        protected override string VehicleType => "Truck";

        private readonly bool _bodyWork = true; // кузов

        public override void ShowInfo()
        {
            Console.WriteLine($"\tVehicle type: {VehicleType}" +
                              $"\n---Chassis description---" +
                              $"\n\tWheel: {Chassis.Wheel}" +
                              $"\n\tChassis Vin number: {Chassis.VinChassis}" +
                              $"\n\tChassis safe load: {Chassis.SafeLoad}" +
                              $"\n\tBodyWork: {_bodyWork.ToString().ToLower()}" +
                              $"\n---Engine description---" +
                              $"\n\tPower: {Engine.Power}" +
                              $"\n\tCapacity: {Engine.EngineCapacity}" +
                              $"\n\tEngine type: {Engine.EngineType}" +
                              $"\n\tEngine Vin number: {Engine.VinNumber}" +
                              $"\n---Transmission description---" +
                              $"\n\tTransmission type: {Transmission.TransmissionType}" +
                              $"\n\tNumber of transmission: {Transmission.NumberOfTransmission}" +
                              $"\n\tVendor: {Transmission.Vendor}");
        }
    }
}
