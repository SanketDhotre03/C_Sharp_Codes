// Program: DataContractSerialize
// Difficulty: High
// Description: Uses DataContractSerializer for XML serialization.
using System;
using System.IO;
using System.Runtime.Serialization;

class DataContractSerialize
{
    [DataContract(Namespace = "http://example.com/order")]
    class Order
    {
        [DataMember(Order = 1)] public int Id { get; set; }
        [DataMember(Order = 2)] public string Customer { get; set; }
        [DataMember(Order = 3)] public decimal Total { get; set; }
        [DataMember(Order = 4)] public DateTime OrderDate { get; set; }
        [IgnoreDataMember] public string InternalNote { get; set; }
    }

    static void Main(string[] args)
    {
        var order = new Order
        {
            Id = 1001,
            Customer = "Alice Smith",
            Total = 299.99m,
            OrderDate = DateTime.Now,
            InternalNote = "This should not appear"
        };

        var serializer = new DataContractSerializer(typeof(Order));
        using var ms = new MemoryStream();
        serializer.WriteObject(ms, order);
        string xml = System.Text.Encoding.UTF8.GetString(ms.ToArray());
        Console.WriteLine("DataContract XML:");
        Console.WriteLine(xml);

        ms.Position = 0;
        var restored = (Order)serializer.ReadObject(ms);
        Console.WriteLine($"\nRestored: Order #{restored.Id} for {restored.Customer} - ${restored.Total}");
        Console.WriteLine($"InternalNote: '{restored.InternalNote}'");
    }
}
