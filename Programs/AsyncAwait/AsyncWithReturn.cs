// Program: AsyncWithReturn
// Difficulty: Medium
// Description: Async method that returns a computed value.
using System;
using System.Threading.Tasks;

class AsyncWithReturn
{
    static async Task<int> ComputeAsync(int n)
    {
        await Task.Delay(50);
        return n * n;
    }

    static async Task<double> AverageAsync(int[] nums)
    {
        int sum = 0;
        foreach (var n in nums) sum += await ComputeAsync(n);
        return (double)sum / nums.Length;
    }

    static async Task Main(string[] args)
    {
        int[] nums = { 2, 3, 4, 5 };
        double avg = await AverageAsync(nums);
        Console.WriteLine($"Average of squares: {avg}");
    }
}
