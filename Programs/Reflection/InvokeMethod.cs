// Program: InvokeMethod
// Difficulty: Medium
// Description: Invokes methods dynamically at runtime using reflection.
using System;
using System.Reflection;

class InvokeMethod
{
    class MathHelper
    {
        public int Square(int n) => n * n;
        public double Power(double b, int e) => Math.Pow(b, e);
        public static string Repeat(string s, int times) => string.Concat(Enumerable.Repeat(s, times));

        private string Secret() => "hidden result";
    }

    static void Main(string[] args)
    {
        var helper = new MathHelper();
        Type t = typeof(MathHelper);

        // Invoke public instance method
        var square = t.GetMethod("Square");
        Console.WriteLine($"Square(7) = {square.Invoke(helper, new object[] { 7 })}");

        // Invoke method with multiple params
        var power = t.GetMethod("Power");
        Console.WriteLine($"Power(2, 10) = {power.Invoke(helper, new object[] { 2.0, 10 })}");

        // Invoke static method
        var repeat = t.GetMethod("Repeat");
        Console.WriteLine($"Repeat('ab', 4) = {repeat.Invoke(null, new object[] { "ab", 4 })}");

        // Invoke private method
        var secret = t.GetMethod("Secret", BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine($"Secret() = {secret.Invoke(helper, null)}");
    }
}

static class Enumerable {
    public static System.Collections.Generic.IEnumerable<T> Repeat<T>(T element, int count) =>
        System.Linq.Enumerable.Repeat(element, count);
}
