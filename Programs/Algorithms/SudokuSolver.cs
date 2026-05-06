// Program: SudokuSolver
// Difficulty: High
// Description: Solves a 9x9 Sudoku puzzle using backtracking.
// Complexity: O(9^(n*n)) worst case
using System;

class SudokuSolver
{
    static bool IsValid(int[,] board, int row, int col, int num)
    {
        for (int x = 0; x < 9; x++)
            if (board[row, x] == num || board[x, col] == num) return false;
        int startRow = row - row % 3, startCol = col - col % 3;
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (board[i + startRow, j + startCol] == num) return false;
        return true;
    }

    static bool Solve(int[,] board)
    {
        for (int row = 0; row < 9; row++)
            for (int col = 0; col < 9; col++)
                if (board[row, col] == 0)
                {
                    for (int num = 1; num <= 9; num++)
                        if (IsValid(board, row, col, num))
                        {
                            board[row, col] = num;
                            if (Solve(board)) return true;
                            board[row, col] = 0;
                        }
                    return false;
                }
        return true;
    }

    static void Main(string[] args)
    {
        int[,] board = {
            {5,3,0,0,7,0,0,0,0},{6,0,0,1,9,5,0,0,0},{0,9,8,0,0,0,0,6,0},
            {8,0,0,0,6,0,0,0,3},{4,0,0,8,0,3,0,0,1},{7,0,0,0,2,0,0,0,6},
            {0,6,0,0,0,0,2,8,0},{0,0,0,4,1,9,0,0,5},{0,0,0,0,8,0,0,7,9}
        };
        Solve(board);
        Console.WriteLine("Solved Sudoku:");
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++) Console.Write(board[i, j] + " ");
            Console.WriteLine();
        }
    }
}
