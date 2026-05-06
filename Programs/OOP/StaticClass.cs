// Program: StaticClass
// Difficulty: Medium
// Description: Demonstrates static classes for utility functions.
using System;
using System.Collections.Generic;

static class MathUtils
{
    public static double DegreesToRadians(double degrees) => degrees * Math.PI / 180;
    public static double RadiansToDegrees(double radians) => radians * 180 / Math.PI;
    public static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++) if (n % i == 0) return false;
        return true;
    }
    public static long Factorial(int n) => n <= 1 ? 1 : n * Factorial(n - 1);
    public static int[] Range(int start, int end) {
        var list = new List<int>();
        for (int i = start; i <= end; i++) list.Add(i);
        return list.ToArray();
    }
}

class StaticClass
{
    static void Main(string[] args)
    {
        Console.WriteLine($"90 degrees = {MathUtils.DegreesToRadians(90):F4} radians");
        Console.WriteLine($"Is 17 prime? {MathUtils.IsPrime(17)}");
        Console.WriteLine($"10! = {MathUtils.Factorial(10)}");
        Console.WriteLine($"Range 1-5: {string.Join(", ", MathUtils.Range(1, 5))}");
    }
}
