namespace Jumpstart.VehicleFleet.TechnicalSpecs
{
    public class Chassis
    {
        public byte NumberOfWheel { get; set; } // количество колес
        public string VinNumber { get; set; } // номер
        public ushort SafeLoad { get; set; } // допустимая нагрузка

        public Chassis(string vinNumber, ushort safeLoad, byte numberOfWheel = 4)
        {
            this.NumberOfWheel = numberOfWheel;
            this.VinNumber = vinNumber;
            this.SafeLoad = safeLoad;
        }

        public Chassis() { }
    }
}