// Program: TaskParallelLibrary
// Difficulty: Medium
// Description: Uses TPL (Task Parallel Library) for parallel work execution.
using System;
using System.Threading.Tasks;
using System.Diagnostics;

class TaskParallelLibrary
{
    static int HeavyCompute(int n)
    {
        // Simulate heavy work
        int result = 0;
        for (int i = 1; i <= n * 1000; i++) result += i;
        return result;
    }

    static void Main(string[] args)
    {
        int[] inputs = { 100, 200, 300, 400, 500 };
        int[] results = new int[inputs.Length];

        var sw = Stopwatch.StartNew();
        Parallel.For(0, inputs.Length, i => results[i] = HeavyCompute(inputs[i]));
        sw.Stop();

        for (int i = 0; i < inputs.Length; i++)
            Console.WriteLine($"HeavyCompute({inputs[i]}) = {results[i]}");
        Console.WriteLine($"Parallel time: {sw.ElapsedMilliseconds}ms");
    }
}
