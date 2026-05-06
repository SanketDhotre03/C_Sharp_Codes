// Program: BinarySearch
// Difficulty: Medium
// Description: Implements binary search algorithm on a sorted array.
// Complexity: O(log n) time, O(1) space
using System;

class BinarySearch
{
    static int Search(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target) return mid;
            if (arr[mid] < target) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }

    static void Main(string[] args)
    {
        int[] arr = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
        int target = 23;
        int result = Search(arr, target);
        Console.WriteLine(result >= 0
            ? $"Found {target} at index {result}"
            : $"{target} not found");
    }
}
