// Program: TwoSum
// Difficulty: Medium
// Description: Finds two indices in an array that add up to a target value.
// Complexity: O(n) time with hash map
using System;
using System.Collections.Generic;

class TwoSum
{
    static (int, int) Find(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.ContainsKey(complement)) return (map[complement], i);
            map[nums[i]] = i;
        }
        return (-1, -1);
    }

    static void Main(string[] args)
    {
        int[] nums = { 2, 7, 11, 15 };
        var (i, j) = Find(nums, 9);
        Console.WriteLine($"Indices: [{i}, {j}]");
    }
}
