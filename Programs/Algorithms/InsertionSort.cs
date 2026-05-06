// Program: InsertionSort
// Difficulty: Medium
// Description: Sorts an array by inserting each element into its correct position.
// Complexity: O(n^2) time, O(1) space
using System;

class InsertionSort
{
    static void Sort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i], j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }

    static void Main(string[] args)
    {
        int[] arr = { 12, 11, 13, 5, 6 };
        Sort(arr);
        Console.WriteLine("Sorted: " + string.Join(", ", arr));
    }
}
