// Program: TupleTypes
// Difficulty: Medium
// Description: Demonstrates tuples and named tuples in C#.
using System;
using System.Collections.Generic;

class TupleTypes
{
    static (double Min, double Max, double Average) Statistics(int[] nums)
    {
        double min = nums[0], max = nums[0], sum = 0;
        foreach (int n in nums)
        {
            if (n < min) min = n;
            if (n > max) max = n;
            sum += n;
        }
        return (min, max, sum / nums.Length);
    }

    static (bool Success, string Message, int Value) ParseInt(string input)
    {
        if (int.TryParse(input, out int value))
            return (true, "Parsed successfully", value);
        return (false, $"Cannot parse '{input}'", 0);
    }

    static void Main(string[] args)
    {
        int[] data = { 5, 2, 8, 1, 9, 3 };
        var (min, max, avg) = Statistics(data);
        Console.WriteLine($"Min={min}, Max={max}, Avg={avg:F2}");

        var (ok, msg, val) = ParseInt("42");
        Console.WriteLine($"Success={ok}, Value={val}, Message={msg}");

        var (ok2, msg2, _) = ParseInt("abc");
        Console.WriteLine($"Success={ok2}, Message={msg2}");

        var dict = new Dictionary<string, (int Age, string City)>
        {
            ["Alice"] = (30, "New York"),
            ["Bob"]   = (25, "Chicago")
        };
        foreach (var (name, info) in dict)
            Console.WriteLine($"{name}: age={info.Age}, city={info.City}");
    }
}
