// Program: SieveOfEratosthenes
// Difficulty: Medium
// Description: Finds all prime numbers up to N using the Sieve of Eratosthenes.
// Complexity: O(n log log n) time
using System;

class SieveOfEratosthenes
{
    static int[] GetPrimes(int n)
    {
        bool[] sieve = new bool[n + 1];
        Array.Fill(sieve, true);
        sieve[0] = sieve[1] = false;
        for (int i = 2; i * i <= n; i++)
            if (sieve[i])
                for (int j = i * i; j <= n; j += i)
                    sieve[j] = false;
        var primes = new System.Collections.Generic.List<int>();
        for (int i = 2; i <= n; i++)
            if (sieve[i]) primes.Add(i);
        return primes.ToArray();
    }

    static void Main(string[] args)
    {
        int[] primes = GetPrimes(50);
        Console.WriteLine("Primes up to 50: " + string.Join(", ", primes));
    }
}
