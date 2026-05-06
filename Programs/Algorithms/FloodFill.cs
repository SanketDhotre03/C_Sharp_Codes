// Program: FloodFill
// Difficulty: Medium
// Description: Implements flood fill algorithm (as used in paint programs).
// Complexity: O(n * m) time
using System;

class FloodFill
{
    static void Fill(int[,] image, int row, int col, int color, int newColor)
    {
        if (row < 0 || col < 0 || row >= image.GetLength(0) || col >= image.GetLength(1)) return;
        if (image[row, col] != color) return;
        image[row, col] = newColor;
        Fill(image, row + 1, col, color, newColor);
        Fill(image, row - 1, col, color, newColor);
        Fill(image, row, col + 1, color, newColor);
        Fill(image, row, col - 1, color, newColor);
    }

    static void Main(string[] args)
    {
        int[,] image = {
            {1, 1, 1, 2},
            {1, 1, 0, 2},
            {1, 0, 2, 2}
        };
        Fill(image, 0, 0, 1, 3);
        Console.WriteLine("After flood fill:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++) Console.Write(image[i, j] + " ");
            Console.WriteLine();
        }
    }
}
