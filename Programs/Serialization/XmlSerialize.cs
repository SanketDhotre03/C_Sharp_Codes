// Program: XmlSerialize
// Difficulty: Medium
// Description: Serializes objects to XML using XmlSerializer.
using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

class XmlSerialize
{
    [XmlRoot("Library")]
    public class Library
    {
        [XmlElement("Book")]
        public List<Book> Books { get; set; } = new List<Book>();
    }

    public class Book
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlElement("Author")]
        public string Author { get; set; }
        [XmlElement("Year")]
        public int Year { get; set; }
    }

    static void Main(string[] args)
    {
        var library = new Library
        {
            Books = new List<Book>
            {
                new Book { Id=1, Title="C# in Depth", Author="Jon Skeet", Year=2019 },
                new Book { Id=2, Title="Clean Code", Author="Robert Martin", Year=2008 }
            }
        };

        var serializer = new XmlSerializer(typeof(Library));
        using var writer = new StringWriter();
        serializer.Serialize(writer, library);
        Console.WriteLine(writer.ToString());
    }
}
