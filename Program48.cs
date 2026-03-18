using System;

class Program48
{
    static int BinarySearch(int[] arr, int left, int right, int target)
    {
        if (left > right) return -1;
        int mid = (left + right) / 2;
        if (arr[mid] == target) return mid;
        if (arr[mid] > target) return BinarySearch(arr, left, mid - 1, target);
        return BinarySearch(arr, mid + 1, right, target);
    }

    static void Main()
    {
        int[] arr = { 2, 4, 6, 8, 10, 12 };
        Console.WriteLine(BinarySearch(arr, 0, arr.Length - 1, 10));
    }
}
