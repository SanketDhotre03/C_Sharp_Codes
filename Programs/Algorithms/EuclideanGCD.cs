// Program: EuclideanGCD
// Difficulty: Medium
// Description: Finds GCD of two numbers using the Euclidean algorithm.
// Complexity: O(log(min(a,b))) time
using System;

class EuclideanGCD
{
    static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
    static int LCM(int a, int b) => a / GCD(a, b) * b;

    static void Main(string[] args)
    {
        int a = 48, b = 18;
        Console.WriteLine($"GCD({a}, {b}) = {GCD(a, b)}");
        Console.WriteLine($"LCM({a}, {b}) = {LCM(a, b)}");
    }
}
