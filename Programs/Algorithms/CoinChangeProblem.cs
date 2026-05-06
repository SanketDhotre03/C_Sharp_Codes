// Program: CoinChangeProblem
// Difficulty: High
// Description: Finds minimum coins needed to make a given amount using DP.
// Complexity: O(amount * coins) time and space
using System;

class CoinChangeProblem
{
    static int MinCoins(int[] coins, int amount)
    {
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;
        foreach (int coin in coins)
            for (int i = coin; i <= amount; i++)
                dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
        return dp[amount] > amount ? -1 : dp[amount];
    }

    static void Main(string[] args)
    {
        int[] coins = { 1, 5, 6, 9 };
        int amount = 11;
        Console.WriteLine($"Minimum coins for {amount}: {MinCoins(coins, amount)}");
    }
}
