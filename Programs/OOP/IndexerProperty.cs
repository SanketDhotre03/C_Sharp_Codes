// Program: IndexerProperty
// Difficulty: Medium
// Description: Demonstrates indexers for custom collection access.
using System;
using System.Collections.Generic;

class Matrix
{
    double[,] data;
    int rows, cols;
    public Matrix(int rows, int cols) { this.rows = rows; this.cols = cols; data = new double[rows, cols]; }
    public double this[int row, int col]
    {
        get { ValidateBounds(row, col); return data[row, col]; }
        set { ValidateBounds(row, col); data[row, col] = value; }
    }
    void ValidateBounds(int r, int c)
    {
        if (r < 0 || r >= rows || c < 0 || c >= cols) throw new IndexOutOfRangeException();
    }
    public void Print()
    {
        for (int i = 0; i < rows; i++)
        { for (int j = 0; j < cols; j++) Console.Write($"{data[i,j],6:F1}"); Console.WriteLine(); }
    }
}

class IndexerProperty
{
    static void Main(string[] args)
    {
        var m = new Matrix(3, 3);
        m[0, 0] = 1; m[0, 1] = 2; m[0, 2] = 3;
        m[1, 0] = 4; m[1, 1] = 5; m[1, 2] = 6;
        m[2, 0] = 7; m[2, 1] = 8; m[2, 2] = 9;
        m.Print();
        Console.WriteLine($"m[1,1] = {m[1, 1]}");
    }
}
