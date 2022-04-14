namespace Jumpstart.VehicleFleet.Vehicle
{
    public class Scooter : VehicleRecord
    {
        public override string VehicleType => "Scooter";

        public bool Sidecar { get; set; } // коляска

        public override string ToString()
        {
            return base.ToString() + $"---Further details---\n\tIs sidecar included: {Sidecar}";
        }
    }
}