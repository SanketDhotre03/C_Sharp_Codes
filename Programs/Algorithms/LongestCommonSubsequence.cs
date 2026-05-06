// Program: LongestCommonSubsequence
// Difficulty: High
// Description: Finds the length of the longest common subsequence of two strings.
// Complexity: O(m * n) time and space
using System;

class LongestCommonSubsequence
{
    static int LCS(string s1, string s2)
    {
        int m = s1.Length, n = s2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; i++)
            for (int j = 1; j <= n; j++)
                dp[i, j] = s1[i - 1] == s2[j - 1]
                    ? dp[i - 1, j - 1] + 1
                    : Math.Max(dp[i - 1, j], dp[i, j - 1]);
        return dp[m, n];
    }

    static void Main(string[] args)
    {
        string s1 = "ABCBDAB", s2 = "BDCAB";
        Console.WriteLine($"LCS of '{s1}' and '{s2}': {LCS(s1, s2)}");
    }
}
