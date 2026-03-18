using System;

class Program19
{
    static void Main()
    {
        int[,] a = { { 1, 2 }, { 3, 4 } };
        int[,] b = { { 5, 6 }, { 7, 8 } };
        int[,] sum = new int[2, 2];

        for (int i = 0; i < 2; i++)
        for (int j = 0; j < 2; j++)
            sum[i, j] = a[i, j] + b[i, j];

        Console.WriteLine($"{sum[0,0]} {sum[0,1]}\n{sum[1,0]} {sum[1,1]}");
    }
}
