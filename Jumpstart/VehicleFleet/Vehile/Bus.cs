using System;

namespace Jumpstart.VehicleFleet.Vehile
{
    public class Bus : Vehicle
    {
        public override string VehicleType => "Bus";
        private readonly byte _numberOfPassengersSeats = 80;

        public Bus() { }

        public Bus(byte numberOfPassengers)
        {
            _numberOfPassengersSeats = numberOfPassengers;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"\tVehicle type: {VehicleType} **{CarModel}**" +
                              $"\n---Chassis description---" +
                              $"\n\tWheel: {Chassis.Wheel}" +
                              $"\n\tChassis Vin number: {Chassis.VinChassis}" +
                              $"\n\tChassis safe load: {Chassis.SafeLoad}" +
                              $"\n---Engine description---" +
                              $"\n\tPower: {Engine.Power}" +
                              $"\n\tCapacity: {Engine.EngineCapacity}" +
                              $"\n\tEngine type: {Engine.EngineType}" +
                              $"\n\tEngine Vin number: {Engine.VinNumber}" +
                              $"\n---Transmission description---" +
                              $"\n\tTransmission type: {Transmission.TransmissionType}" +
                              $"\n\tNumber of transmission: {Transmission.NumberOfTransmission}" +
                              $"\n\tVendor: {Transmission.Vendor}" +
                              $"\n---Seating capacity--" +
                              $"\n\tNumber of passengers seats: {_numberOfPassengersSeats}\n");
        }
    }
}