// Program: FibonacciDynamic
// Difficulty: Medium
// Description: Computes Fibonacci numbers using dynamic programming (memoization).
// Complexity: O(n) time, O(n) space
using System;

class FibonacciDynamic
{
    static long Fibonacci(int n, long[] memo)
    {
        if (n <= 1) return n;
        if (memo[n] != 0) return memo[n];
        memo[n] = Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
        return memo[n];
    }

    static void Main(string[] args)
    {
        int n = 20;
        long[] memo = new long[n + 1];
        for (int i = 0; i <= n; i++)
            Console.Write(Fibonacci(i, memo) + " ");
        Console.WriteLine();
    }
}
