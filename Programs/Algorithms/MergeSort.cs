// Program: MergeSort
// Difficulty: Medium
// Description: Sorts an array using the divide-and-conquer merge sort algorithm.
// Complexity: O(n log n) time, O(n) space
using System;

class MergeSort
{
    static void Merge(int[] arr, int l, int m, int r)
    {
        int n1 = m - l + 1, n2 = r - m;
        int[] L = new int[n1], R = new int[n2];
        Array.Copy(arr, l, L, 0, n1);
        Array.Copy(arr, m + 1, R, 0, n2);
        int i = 0, j = 0, k = l;
        while (i < n1 && j < n2)
            arr[k++] = L[i] <= R[j] ? L[i++] : R[j++];
        while (i < n1) arr[k++] = L[i++];
        while (j < n2) arr[k++] = R[j++];
    }

    static void Sort(int[] arr, int l, int r)
    {
        if (l < r)
        {
            int m = (l + r) / 2;
            Sort(arr, l, m);
            Sort(arr, m + 1, r);
            Merge(arr, l, m, r);
        }
    }

    static void Main(string[] args)
    {
        int[] arr = { 38, 27, 43, 3, 9, 82, 10 };
        Sort(arr, 0, arr.Length - 1);
        Console.WriteLine("Sorted: " + string.Join(", ", arr));
    }
}
