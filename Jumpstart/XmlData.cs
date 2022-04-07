using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Jumpstart.VehicleFleet.Vehicle;

namespace Jumpstart
{
    public class XmlData
    {
        // НОВАЯ ПОПЫТКА
        public static void CreateTS(VehicleRecord record)
        {
            string path =
                @"D:\PROJECTS\[Global] Automated Testing Foundations with .NET\Jumpstart\Jumpstart\VehicleFleet\VehiclesWithBigEngineCapacity.xml";

            var xdoc = XDocument.Load(path);
            var xelement1 = new XElement("Vehicle", new XAttribute("id", record.Id), new XElement("Model", record.CarModel));

            var xelement2 = (new XElement("", record.Chassis.VinNumber));
            xelement1.SetAttributeValue("cd", xelement2);
            xdoc.Root.Add(xelement1);
            xdoc.Save(path);
        }
        // 

        public static void WriteCarsWithBigEngineCapacity(IEnumerable<VehicleRecord> list)
        {
            string path =
                @"D:\PROJECTS\[Global] Automated Testing Foundations with .NET\Jumpstart\Jumpstart\VehicleFleet\VehiclesWithBigEngineCapacity.xml";

            XDocument doc = new XDocument(
                new XElement("root",
                    list.Select(x => new XElement("LOL", x))));
            doc.Save(path);


            //var doc = new XmlDocument(); // Создаем Xml документ
            //var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null); // Создаем Xml заголовок (ПОЛУЧИЛОСЬ)
            //doc.AppendChild(xmlDeclaration); // Добавляем заголовок перед корневым элементом (ПОЛУЧИЛОСЬ)

            //// Создаем Корневой элемент
            //var root = doc.CreateElement("carsWithBigEngineCapacity"); // carsWithBigEngineCapacity (ПОЛУЧИЛОСЬ)

            //// Получаем все записи

            //foreach (var car in list)
            //{
            //    // Создаем элемент записи vehicle
            //    var vehicleNode = doc.CreateElement(car.VehicleType); // passengerCar (ВРОДЕ ПОЛУЧИЛОСЬ)


            //    var vehicleAttribute = doc.CreateAttribute("model");  // Создаем атрибут и нужным именем (<PassengerCar model="Mazda RX8">)
            //    vehicleAttribute.InnerText = car.CarModel; // Устанавливаем содержимое атрибута. ("Mazda RX8")


            //    //if (vehicleNode.HasChildNodes)
            //    //{
            //    //    Console.WriteLine(vehicleAttribute.ChildNodes);
            //    //}
            //    foreach (var spec in list) // var spec in vehicleNode
            //    {
            //        var enclosedNode = doc.CreateElement(spec.ToString());
            //        EncloseNode(vehicleNode, enclosedNode);

            //        foreach (var t in enclosedNode)
            //        {
            //            AddChildNode(t.ToString(), enclosedNode.LocalName.ToString(), enclosedNode, doc);
            //        }
            //    }


            ////// Создаем зависимые элементы.
            ////AddChildNode("name", car.Engine.VinNumber, vehicleNode, doc);
            //////AddChildNode("number", phone.Number.ToString(), phoneNode, doc);
            //////AddChildNode("remark", phone.Remark, phoneNode, doc);

            //////// Добавляем запись телефонной книги в каталог.
            //////root.AppendChild(phoneNode);



            //// 1
            //var chasssisNode = doc.CreateElement("chassis"); // chasssis
            //vehicleNode.Attributes.Append(vehicleAttribute); // Добавляем атрибут к элементу

            //EncloseNode(vehicleNode, chasssisNode); // вложить шасси в passengerCar

            // Создаем зависимые элементы.
            //AddChildNode("VinNumber", car.Chassis.VinNumber, chasssisNode, doc);
            // AddChildNode("SafeLoad", car.Chassis.SafeLoad.ToString(), chasssisNode, doc);
            // AddChildNode("NumberOfWheel", car.Chassis.NumberOfWheel.ToString(), chasssisNode, doc);

            //// Добавляем запись в каталог.
            //root.AppendChild(vehicleNode);

            ////2
            //var engineNode = doc.CreateElement("Engine"); // Engine
            //EncloseNode(vehicleNode, engineNode); // вложить мотор в passengerCar
            //AddChildNode("VinNumber", car.Engine.VinNumber, engineNode, doc);
            //AddChildNode("SafeLoad", car.Engine.Capacity.ToString(), engineNode, doc);
            //AddChildNode("NumberOfWheel", car.Engine.Type.ToString(), engineNode, doc);
            //AddChildNode("NumberOfWheel", car.Engine.Power.ToString(), engineNode, doc);

            //    root.AppendChild(vehicleNode);

            //}

            //doc.AppendChild(root);  // Добавляем новый корневой элемент в документ.

            //doc.Save(path); // Сохраняем документ.
        }

        /// <summary>
        /// Добавить зависимый элемент с текстом.
        /// </summary>
        /// <param name="childName"> Имя дочернего элемента. </param>
        /// <param name="childText"> Текст, который будет внутри дочернего элемента. </param>
        /// <param name="parentNode"> Родительский элемент. </param>
        /// <param name="doc"> Xml документ. </param>
        private static void AddChildNode(string childName, string childText, XmlElement parentNode, XmlDocument doc)
        {
            var child = doc.CreateElement(childName);
            child.InnerText = childText;
            parentNode.AppendChild(child);
        }

        private static void EncloseNode(XmlNode parentNode, XmlNode childNode)
        {
            parentNode.AppendChild(childNode);
        }
    }
}
