using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Homework12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Triangle> listOfTriangles = new List<Triangle>()
            {
                new Triangle(new Point(1,2), new Point(4,-1), new Point(3,12)),
                new Triangle(new Point(0,3), new Point(2,3), new Point(3,10)),
                new Triangle(new Point(6,0), new Point(2,5), new Point(3,0)),
                new Triangle(new Point(1,-4), new Point(7,2), new Point(2,2)),
                new Triangle(new Point(0,-2), new Point(-7,-1), new Point(1,1))
            };

            //BinarySerialization
            //00Serialization00
            IFormatter formatter = new BinaryFormatter();
            Stream binStream = new FileStream("ListOfTrianglesBinary.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(binStream, listOfTriangles);
            binStream.Close();
            //00Deserialization00
            binStream = new FileStream("ListOfTrianglesBinary.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Triangle> deserializedListOfTiangles = (List<Triangle>)formatter.Deserialize(binStream);
            if (deserializedListOfTiangles != null)
            {
                foreach (Triangle triangle in deserializedListOfTiangles)
                {
                    triangle.TriangleOutput();
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Convertation ERROR!!!");
            }
            binStream.Close();

            //XMLSerialization
            //<Serialization/>
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Triangle>));
            Stream xmlStream = new FileStream("ListOfTrianglesXML.xml", FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(xmlStream, listOfTriangles);
            xmlStream.Close();
            //<Deserialization/>
            xmlStream = new FileStream("ListOfTrianglesXML.xml", FileMode.Open);
            deserializedListOfTiangles = xmlSerializer.Deserialize(xmlStream) as List<Triangle>;
            if (deserializedListOfTiangles != null)
            {
                foreach (Triangle triangle in deserializedListOfTiangles)
                {
                    triangle.TriangleOutput();
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Convertation ERROR!!!");
            }
            xmlStream.Close();

            //JSONSerialization
            //{"text" : "Serialization"}
            Stream jsonStream = new FileStream("ListOfTrianglesJSON.json", FileMode.Create);
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Triangle>));
            jsonSerializer.WriteObject(jsonStream, listOfTriangles);
            //{"text" : "Deserialization"}
            jsonStream.Position = 0;
            deserializedListOfTiangles = (List<Triangle>)jsonSerializer.ReadObject(jsonStream);
            if (deserializedListOfTiangles != null)
            {
                foreach (Triangle triangle in deserializedListOfTiangles)
                {
                    triangle.TriangleOutput();
                }
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("Convertation ERROR!!!");
            }
            jsonStream.Close();

            Console.Write("Press any key on your keyboard...");
            Console.ReadKey();
        }
    }
}
