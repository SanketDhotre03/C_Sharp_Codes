// Program: HeapSort
// Difficulty: Medium
// Description: Sorts an array using the heap sort algorithm.
// Complexity: O(n log n) time, O(1) space
using System;

class HeapSort
{
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i, l = 2 * i + 1, r = 2 * i + 2;
        if (l < n && arr[l] > arr[largest]) largest = l;
        if (r < n && arr[r] > arr[largest]) largest = r;
        if (largest != i)
        {
            (arr[i], arr[largest]) = (arr[largest], arr[i]);
            Heapify(arr, n, largest);
        }
    }

    static void Sort(int[] arr)
    {
        int n = arr.Length;
        for (int i = n / 2 - 1; i >= 0; i--) Heapify(arr, n, i);
        for (int i = n - 1; i > 0; i--)
        {
            (arr[0], arr[i]) = (arr[i], arr[0]);
            Heapify(arr, i, 0);
        }
    }

    static void Main(string[] args)
    {
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        Sort(arr);
        Console.WriteLine("Sorted: " + string.Join(", ", arr));
    }
}
