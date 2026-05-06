// Program: Generics
// Difficulty: Medium
// Description: Demonstrates generic classes and methods in C#.
using System;

class Pair<T1, T2>
{
    public T1 First { get; set; }
    public T2 Second { get; set; }
    public Pair(T1 first, T2 second) { First = first; Second = second; }
    public void Swap(out Pair<T2, T1> swapped) => swapped = new Pair<T2, T1>(Second, First);
    public override string ToString() => $"({First}, {Second})";
}

class GenericStack<T>
{
    T[] items = new T[10];
    int top = 0;
    public void Push(T item) => items[top++] = item;
    public T Pop() => items[--top];
    public bool IsEmpty => top == 0;
}

static class GenericHelper
{
    public static T Max<T>(T a, T b) where T : IComparable<T> => a.CompareTo(b) >= 0 ? a : b;
}

class Generics
{
    static void Main(string[] args)
    {
        var pair = new Pair<string, int>("hello", 42);
        Console.WriteLine(pair);
        pair.Swap(out var swapped);
        Console.WriteLine(swapped);

        var stack = new GenericStack<double>();
        stack.Push(1.1); stack.Push(2.2); stack.Push(3.3);
        Console.WriteLine(stack.Pop());

        Console.WriteLine($"Max(3, 7): {GenericHelper.Max(3, 7)}");
        Console.WriteLine($"Max("apple", "banana"): {GenericHelper.Max("apple", "banana")}");
    }
}
