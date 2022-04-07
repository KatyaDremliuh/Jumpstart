namespace Jumpstart.VehicleFleet.TechnicalSpecs
{
  public  class Transmission
    {
        public TransmissionType TransmissionType { get; set; } // тип
        public byte NumberOfTransmission { get; set; } // кол-во передач
        public string Vendor { get; set; } // производитель

        public Transmission(string vendor, byte numberOfTransmission = 5, TransmissionType transmissionType = TransmissionType.Mechanical)
        {
            TransmissionType = transmissionType;
            NumberOfTransmission = numberOfTransmission;
            Vendor = vendor;
        }

        public Transmission() { }
    }
}
