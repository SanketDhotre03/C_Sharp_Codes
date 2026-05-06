// Program: MatrixChainMultiplication
// Difficulty: High
// Description: Finds the optimal order to multiply a chain of matrices using DP.
// Complexity: O(n^3) time
using System;

class MatrixChainMultiplication
{
    static int MatrixChain(int[] p)
    {
        int n = p.Length - 1;
        int[,] m = new int[n, n];
        for (int len = 2; len <= n; len++)
            for (int i = 0; i <= n - len; i++)
            {
                int j = i + len - 1;
                m[i, j] = int.MaxValue;
                for (int k = i; k < j; k++)
                {
                    int cost = m[i, k] + m[k + 1, j] + p[i] * p[k + 1] * p[j + 1];
                    if (cost < m[i, j]) m[i, j] = cost;
                }
            }
        return m[0, n - 1];
    }

    static void Main(string[] args)
    {
        int[] dims = { 10, 30, 5, 60 };
        Console.WriteLine($"Minimum multiplications: {MatrixChain(dims)}");
    }
}
