using System;

class Program18
{
    static void Main()
    {
        int[] arr = { 4, 8, 15, 16, 23, 42 };
        int target = 16;
        int index = -1;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                index = i;
                break;
            }
        }
        Console.WriteLine(index >= 0 ? $"Found at index {index}" : "Not found");
    }
}
