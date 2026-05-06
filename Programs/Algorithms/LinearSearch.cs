// Program: LinearSearch
// Difficulty: Medium
// Description: Searches for an element by checking each element sequentially.
// Complexity: O(n) time, O(1) space
using System;

class LinearSearch
{
    static int Search(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == target) return i;
        return -1;
    }

    static void Main(string[] args)
    {
        int[] arr = { 4, 2, 7, 1, 9, 3 };
        int target = 9;
        int idx = Search(arr, target);
        Console.WriteLine(idx >= 0 ? $"Found at index {idx}" : "Not found");
    }
}
