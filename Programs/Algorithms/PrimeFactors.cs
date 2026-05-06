// Program: PrimeFactors
// Difficulty: Medium
// Description: Finds all prime factors of a given number.
// Complexity: O(sqrt(n)) time
using System;
using System.Collections.Generic;

class PrimeFactors
{
    static List<int> GetPrimeFactors(int n)
    {
        var factors = new List<int>();
        for (int i = 2; i * i <= n; i++)
            while (n % i == 0) { factors.Add(i); n /= i; }
        if (n > 1) factors.Add(n);
        return factors;
    }

    static void Main(string[] args)
    {
        int n = 360;
        Console.WriteLine($"Prime factors of {n}: {string.Join(" x ", GetPrimeFactors(n))}");
    }
}
