// Program: NullableTypes
// Difficulty: Medium
// Description: Demonstrates nullable value types and null-coalescing operators.
using System;

class NullableTypes
{
    static int? TryDivide(int a, int b) => b == 0 ? null : a / b;

    record Config(string Host, int? Port, string? Username)
    {
        public int ActualPort => Port ?? 8080;
        public string ActualUsername => Username ?? "guest";
    }

    static void Main(string[] args)
    {
        int? a = 10, b = null;
        Console.WriteLine($"a has value: {a.HasValue} = {a.Value}");
        Console.WriteLine($"b has value: {b.HasValue}");
        Console.WriteLine($"b ?? 99 = {b ?? 99}");
        Console.WriteLine($"b?.ToString() = {b?.ToString() ?? "null"}");

        Console.WriteLine($"10/2 = {TryDivide(10, 2)}");
        Console.WriteLine($"10/0 = {TryDivide(10, 0) ?? -1}");

        var config = new Config("localhost", null, null);
        Console.WriteLine($"Host: {config.Host}, Port: {config.ActualPort}, User: {config.ActualUsername}");
    }
}
