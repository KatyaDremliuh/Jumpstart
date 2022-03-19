namespace Jumpstart.VehicleFleet.Specs
{
    public class Chassis
    {
        public byte Wheel { get; set; }
        public string VinChassis { get; set; }
        public ushort SafeLoad { get; set; }

        public Chassis(string vinChassis, ushort safeLoad, byte wheel = 4)
        {
            this.Wheel = wheel;
            this.VinChassis = vinChassis;
            this.SafeLoad = safeLoad;
        }

        public Chassis() { }
    }
}
