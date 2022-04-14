using System;

namespace Jumpstart.VehicleFleet.Vehicle
{
    [Serializable]
    public class Truck : VehicleRecord
    {
        public override string VehicleType => "Truck";
    }
}