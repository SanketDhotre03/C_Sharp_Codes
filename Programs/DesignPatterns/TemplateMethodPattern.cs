// Program: TemplateMethodPattern
// Difficulty: Medium
// Description: Template Method defines the skeleton of an algorithm in a base class.
using System;

abstract class DataProcessor
{
    // Template method
    public void Process()
    {
        ReadData();
        ProcessData();
        WriteData();
        Cleanup();
    }

    protected abstract void ReadData();
    protected abstract void ProcessData();
    protected abstract void WriteData();
    protected virtual void Cleanup() => Console.WriteLine("Cleanup done.");
}

class CsvProcessor : DataProcessor
{
    protected override void ReadData()    => Console.WriteLine("Reading CSV file...");
    protected override void ProcessData() => Console.WriteLine("Parsing CSV records...");
    protected override void WriteData()   => Console.WriteLine("Writing to database...");
}

class JsonProcessor : DataProcessor
{
    protected override void ReadData()    => Console.WriteLine("Reading JSON file...");
    protected override void ProcessData() => Console.WriteLine("Deserializing JSON...");
    protected override void WriteData()   => Console.WriteLine("Posting to API...");
    protected override void Cleanup()     { Console.WriteLine("Closing JSON stream."); base.Cleanup(); }
}

class TemplateMethodPattern
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- CSV ---");
        new CsvProcessor().Process();
        Console.WriteLine("--- JSON ---");
        new JsonProcessor().Process();
    }
}
