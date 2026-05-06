// Program: XmlFileReadWrite
// Difficulty: Medium
// Description: Reads and writes XML files using XmlDocument.
using System;
using System.IO;
using System.Xml;

class XmlFileReadWrite
{
    static void Main(string[] args)
    {
        string path = Path.Combine(Path.GetTempPath(), "data.xml");

        // Write XML
        var doc = new XmlDocument();
        var root = doc.CreateElement("employees");
        doc.AppendChild(root);

        string[,] employees = { {"Alice","Engineering","85000"}, {"Bob","Marketing","70000"} };
        for (int i = 0; i < employees.GetLength(0); i++)
        {
            var emp = doc.CreateElement("employee");
            emp.SetAttribute("id", (i+1).ToString());
            var name = doc.CreateElement("name"); name.InnerText = employees[i,0];
            var dept = doc.CreateElement("department"); dept.InnerText = employees[i,1];
            var sal  = doc.CreateElement("salary"); sal.InnerText = employees[i,2];
            emp.AppendChild(name); emp.AppendChild(dept); emp.AppendChild(sal);
            root.AppendChild(emp);
        }
        doc.Save(path);
        Console.WriteLine("Saved XML.");

        // Read XML
        var loaded = new XmlDocument();
        loaded.Load(path);
        foreach (XmlNode node in loaded.SelectNodes("/employees/employee"))
            Console.WriteLine($"  {node["name"].InnerText}: {node["department"].InnerText} (${node["salary"].InnerText})");

        File.Delete(path);
    }
}
