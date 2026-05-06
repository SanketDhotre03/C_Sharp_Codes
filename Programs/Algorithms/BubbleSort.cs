// Program: BubbleSort
// Difficulty: Medium
// Description: Sorts an array using the bubble sort algorithm.
// Complexity: O(n^2) time, O(1) space
using System;

class BubbleSort
{
    static void Sort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
    }

    static void Main(string[] args)
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        Sort(arr);
        Console.WriteLine("Sorted: " + string.Join(", ", arr));
    }
}
