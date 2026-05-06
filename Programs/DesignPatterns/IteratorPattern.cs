// Program: IteratorPattern
// Difficulty: Medium
// Description: Iterator pattern using C# IEnumerable and yield return.
using System;
using System.Collections;
using System.Collections.Generic;

class NumberRange : IEnumerable<int>
{
    int start, end, step;
    public NumberRange(int start, int end, int step = 1)
    { this.start = start; this.end = end; this.step = step; }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = start; i <= end; i += step)
            yield return i;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class FibonacciSequence : IEnumerable<long>
{
    int count;
    public FibonacciSequence(int count) => this.count = count;
    public IEnumerator<long> GetEnumerator()
    {
        long a = 0, b = 1;
        for (int i = 0; i < count; i++)
        { yield return a; (a, b) = (b, a + b); }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class IteratorPattern
{
    static void Main(string[] args)
    {
        Console.WriteLine("Evens 0-10: " + string.Join(", ", new NumberRange(0, 10, 2)));
        Console.WriteLine("Fibonacci 10: " + string.Join(", ", new FibonacciSequence(10)));
    }
}
