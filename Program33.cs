using System;

class Program33
{
    static void Main()
    {
        string binary = "11001";
        int decimalValue = Convert.ToInt32(binary, 2);
        Console.WriteLine($"Decimal value is {decimalValue}");
    }
}
