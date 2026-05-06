// Program: AdapterPattern
// Difficulty: Medium
// Description: Adapter pattern to make incompatible interfaces work together.
using System;

class XmlDataProvider
{
    public string GetXml() => "<data><item>Alpha</item><item>Beta</item></data>";
}

interface IJsonProvider { string GetJson(); }

class XmlToJsonAdapter : IJsonProvider
{
    private XmlDataProvider _xml;
    public XmlToJsonAdapter(XmlDataProvider xml) => _xml = xml;
    public string GetJson()
    {
        // simplified conversion
        var xml = _xml.GetXml();
        return xml.Replace("<data>", "{"items":[")
                  .Replace("</data>", "]}")
                  .Replace("<item>", """)
                  .Replace("</item>", "",");
    }
}

class DataConsumer
{
    public void Process(IJsonProvider provider) =>
        Console.WriteLine("Processing JSON: " + provider.GetJson());
}

class AdapterPattern
{
    static void Main(string[] args)
    {
        var xmlProvider = new XmlDataProvider();
        IJsonProvider adapter = new XmlToJsonAdapter(xmlProvider);
        new DataConsumer().Process(adapter);
    }
}
