// Program: QuickSort
// Difficulty: Medium
// Description: Sorts an array using the quick sort algorithm with last element as pivot.
// Complexity: O(n log n) average, O(n^2) worst case
using System;

class QuickSort
{
    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high], i = low - 1;
        for (int j = low; j < high; j++)
            if (arr[j] <= pivot)
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return i + 1;
    }

    static void Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            Sort(arr, low, pi - 1);
            Sort(arr, pi + 1, high);
        }
    }

    static void Main(string[] args)
    {
        int[] arr = { 10, 7, 8, 9, 1, 5 };
        Sort(arr, 0, arr.Length - 1);
        Console.WriteLine("Sorted: " + string.Join(", ", arr));
    }
}
