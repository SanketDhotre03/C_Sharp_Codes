// Program: StrategyPattern
// Difficulty: Medium
// Description: Strategy pattern allows runtime algorithm selection.
using System;

interface ISortStrategy { void Sort(int[] arr); string Name { get; } }

class BubbleSortStrategy : ISortStrategy
{
    public string Name => "Bubble Sort";
    public void Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = 0; j < arr.Length - i - 1; j++)
                if (arr[j] > arr[j+1]) (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
    }
}

class QuickSortStrategy : ISortStrategy
{
    public string Name => "Quick Sort";
    public void Sort(int[] arr) => Array.Sort(arr);
}

class Sorter
{
    private ISortStrategy _strategy;
    public Sorter(ISortStrategy strategy) => _strategy = strategy;
    public void SetStrategy(ISortStrategy s) => _strategy = s;
    public void Sort(int[] arr)
    {
        Console.Write($"Using {_strategy.Name}: ");
        _strategy.Sort(arr);
        Console.WriteLine(string.Join(", ", arr));
    }
}

class StrategyPattern
{
    static void Main(string[] args)
    {
        int[] data1 = { 5, 2, 8, 1, 9 };
        int[] data2 = { 3, 7, 4, 2, 6 };
        var sorter = new Sorter(new BubbleSortStrategy());
        sorter.Sort(data1);
        sorter.SetStrategy(new QuickSortStrategy());
        sorter.Sort(data2);
    }
}
