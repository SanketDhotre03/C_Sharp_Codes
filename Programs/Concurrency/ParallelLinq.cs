// Program: ParallelLinq
// Difficulty: Medium
// Description: Uses PLINQ (Parallel LINQ) for data-parallel queries.
using System;
using System.Diagnostics;
using System.Linq;

class ParallelLinq
{
    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++) if (n % i == 0) return false;
        return true;
    }

    static void Main(string[] args)
    {
        int max = 100000;

        var sw = Stopwatch.StartNew();
        var seqPrimes = Enumerable.Range(2, max).Where(IsPrime).Count();
        sw.Stop();
        Console.WriteLine($"Sequential: {seqPrimes} primes in {sw.ElapsedMilliseconds}ms");

        sw.Restart();
        var parPrimes = ParallelEnumerable.Range(2, max).Where(IsPrime).Count();
        sw.Stop();
        Console.WriteLine($"Parallel:   {parPrimes} primes in {sw.ElapsedMilliseconds}ms");
    }
}
