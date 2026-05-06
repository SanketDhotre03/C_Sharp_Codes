// Program: ReflectionPerformance
// Difficulty: High
// Description: Compares direct invocation vs reflection for performance.
using System;
using System.Diagnostics;
using System.Reflection;

class ReflectionPerformance
{
    static int Square(int n) => n * n;

    static void Main(string[] args)
    {
        const int ITERATIONS = 1_000_000;

        // Direct invocation
        var sw = Stopwatch.StartNew();
        int result = 0;
        for (int i = 0; i < ITERATIONS; i++) result += Square(i);
        sw.Stop();
        Console.WriteLine($"Direct:     {sw.ElapsedMilliseconds}ms (result={result})");

        // Reflection invoke
        var method = typeof(ReflectionPerformance).GetMethod(nameof(Square),
            BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        sw.Restart();
        result = 0;
        for (int i = 0; i < ITERATIONS; i++) result += (int)method.Invoke(null, new object[] { i });
        sw.Stop();
        Console.WriteLine($"Reflection: {sw.ElapsedMilliseconds}ms (result={result})");

        // Delegate cached
        var del = (Func<int, int>)Delegate.CreateDelegate(typeof(Func<int, int>), method);
        sw.Restart();
        result = 0;
        for (int i = 0; i < ITERATIONS; i++) result += del(i);
        sw.Stop();
        Console.WriteLine($"Delegate:   {sw.ElapsedMilliseconds}ms (result={result})");
    }
}
