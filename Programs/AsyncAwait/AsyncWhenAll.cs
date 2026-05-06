// Program: AsyncWhenAll
// Difficulty: Medium
// Description: Runs multiple independent tasks concurrently using WhenAll.
using System;
using System.Linq;
using System.Threading.Tasks;

class AsyncWhenAll
{
    static async Task<int> SquareAsync(int n)
    {
        await Task.Delay(50);
        return n * n;
    }

    static async Task Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4, 5 };
        var tasks = nums.Select(n => SquareAsync(n));
        int[] squares = await Task.WhenAll(tasks);
        Console.WriteLine("Squares: " + string.Join(", ", squares));
        Console.WriteLine("Sum of squares: " + squares.Sum());
    }
}
