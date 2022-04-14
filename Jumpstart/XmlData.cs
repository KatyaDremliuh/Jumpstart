using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Jumpstart.VehicleFleet.Vehicle;

namespace Jumpstart
{
    public class XmlData
    {
        public static void WriteCarsWithBigEngineCapacity(IEnumerable<VehicleRecord> records)
        {
            //string path =
            //    @"D:\PROJECTS\[Global] Automated Testing Foundations with .NET\Jumpstart\Jumpstart\VehicleFleet\VehiclesWithBigEngineCapacity.xml";

            string path =
                @"D:\PROJECTS\[Global] Automated Testing Foundations with .NET\Jumpstart\Jumpstart\BigEngineCapacity.xml";


            XmlSerializer xmlSerializer = new XmlSerializer(typeof(VehicleRecord));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach (var VARIABLE in records)
                {
                    xmlSerializer.Serialize(fs, VARIABLE);
                }


                Console.WriteLine("Object has been serialized");
            }
        }
    }
}
