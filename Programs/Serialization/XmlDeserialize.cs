// Program: XmlDeserialize
// Difficulty: Medium
// Description: Deserializes XML to C# objects using XmlSerializer.
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

class XmlDeserialize
{
    [XmlRoot("Employees")]
    public class EmployeeList { [XmlElement("Employee")] public List<Employee> Items { get; set; } }
    public class Employee
    {
        [XmlAttribute] public int Id { get; set; }
        [XmlElement] public string Name { get; set; }
        [XmlElement] public string Role { get; set; }
    }

    static void Main(string[] args)
    {
        string xml = @"<?xml version=""1.0""?>
<Employees>
  <Employee Id=""1""><Name>Alice</Name><Role>Dev</Role></Employee>
  <Employee Id=""2""><Name>Bob</Name><Role>QA</Role></Employee>
</Employees>";

        var serializer = new XmlSerializer(typeof(EmployeeList));
        using var reader = new StringReader(xml);
        var list = (EmployeeList)serializer.Deserialize(reader);
        foreach (var e in list.Items)
            Console.WriteLine($"[{e.Id}] {e.Name} - {e.Role}");
    }
}
