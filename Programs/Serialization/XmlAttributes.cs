// Program: XmlAttributes
// Difficulty: Medium
// Description: Demonstrates XML serialization attributes for custom output.
using System;
using System.IO;
using System.Xml.Serialization;

class XmlAttributes
{
    [XmlRoot("Person", Namespace = "http://example.com")]
    public class Person
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("FullName")]
        public string Name { get; set; }

        [XmlElement("DateOfBirth")]
        public DateTime Birthday { get; set; }

        [XmlArray("Contacts")]
        [XmlArrayItem("Contact")]
        public string[] PhoneNumbers { get; set; }

        [XmlIgnore]
        public string SecretField { get; set; }
    }

    static void Main(string[] args)
    {
        var person = new Person
        {
            Id = 1, Name = "Alice Smith",
            Birthday = new DateTime(1990, 5, 20),
            PhoneNumbers = new[] { "+1-555-1234", "+1-555-5678" },
            SecretField = "ignored"
        };

        var ser = new XmlSerializer(typeof(Person));
        using var sw = new StringWriter();
        ser.Serialize(sw, person);
        Console.WriteLine(sw.ToString());
    }
}
