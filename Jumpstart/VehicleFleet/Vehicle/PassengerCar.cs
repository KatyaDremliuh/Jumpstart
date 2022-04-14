using System;
using Jumpstart.VehicleFleet.TechnicalSpecs;

namespace Jumpstart.VehicleFleet.Vehicle
{
    [Serializable]
    public class PassengerCar : VehicleRecord
    {
        public override string VehicleType => "PassengerCar";
        public BodyType BodyType { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"---Further details---\n\tBody type: {BodyType}";
        }
    }
}