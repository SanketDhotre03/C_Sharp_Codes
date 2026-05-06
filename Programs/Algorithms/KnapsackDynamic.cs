// Program: KnapsackDynamic
// Difficulty: High
// Description: Solves the 0/1 knapsack problem using dynamic programming.
// Complexity: O(n * W) time and space
using System;

class KnapsackDynamic
{
    static int Knapsack(int W, int[] wt, int[] val, int n)
    {
        int[,] dp = new int[n + 1, W + 1];
        for (int i = 1; i <= n; i++)
            for (int w = 0; w <= W; w++)
            {
                dp[i, w] = dp[i - 1, w];
                if (wt[i - 1] <= w)
                    dp[i, w] = Math.Max(dp[i, w], dp[i - 1, w - wt[i - 1]] + val[i - 1]);
            }
        return dp[n, W];
    }

    static void Main(string[] args)
    {
        int[] val = { 60, 100, 120 };
        int[] wt  = { 10,  20,  30 };
        int W = 50, n = val.Length;
        Console.WriteLine($"Maximum value in knapsack: {Knapsack(W, wt, val, n)}");
    }
}
