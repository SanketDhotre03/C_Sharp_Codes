// Program: SparseMatrix
// Difficulty: Medium
// Description: Efficiently stores and multiplies sparse matrices.
using System;
using System.Collections.Generic;

class SparseMatrix
{
    Dictionary<(int, int), double> data = new Dictionary<(int, int), double>();
    int rows, cols;

    SparseMatrix(int rows, int cols) { this.rows = rows; this.cols = cols; }

    void Set(int r, int c, double val) { if (val != 0) data[(r, c)] = val; }
    double Get(int r, int c) => data.TryGetValue((r, c), out double v) ? v : 0;

    void Display()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++) Console.Write($"{Get(i, j),5}");
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        var m = new SparseMatrix(4, 4);
        m.Set(0, 0, 5); m.Set(1, 2, 3); m.Set(3, 1, 7);
        Console.WriteLine("Sparse Matrix:");
        m.Display();
        Console.WriteLine($"Non-zero elements: {m.data.Count}");
    }
}
