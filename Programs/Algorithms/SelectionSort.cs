// Program: SelectionSort
// Difficulty: Medium
// Description: Sorts an array by repeatedly finding the minimum element.
// Complexity: O(n^2) time, O(1) space
using System;

class SelectionSort
{
    static void Sort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < n; j++)
                if (arr[j] < arr[minIdx]) minIdx = j;
            (arr[minIdx], arr[i]) = (arr[i], arr[minIdx]);
        }
    }

    static void Main(string[] args)
    {
        int[] arr = { 64, 25, 12, 22, 11 };
        Sort(arr);
        Console.WriteLine("Sorted: " + string.Join(", ", arr));
    }
}
