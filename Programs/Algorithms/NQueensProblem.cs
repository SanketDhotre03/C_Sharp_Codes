// Program: NQueensProblem
// Difficulty: High
// Description: Solves the N-Queens problem using backtracking.
// Complexity: O(n!) time
using System;

class NQueensProblem
{
    static int N;

    static bool IsSafe(int[,] board, int row, int col)
    {
        for (int i = 0; i < col; i++)
            if (board[row, i] == 1) return false;
        for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 1) return false;
        for (int i = row, j = col; i < N && j >= 0; i++, j--)
            if (board[i, j] == 1) return false;
        return true;
    }

    static bool Solve(int[,] board, int col)
    {
        if (col >= N) return true;
        for (int i = 0; i < N; i++)
        {
            if (IsSafe(board, i, col))
            {
                board[i, col] = 1;
                if (Solve(board, col + 1)) return true;
                board[i, col] = 0;
            }
        }
        return false;
    }

    static void Main(string[] args)
    {
        N = 8;
        int[,] board = new int[N, N];
        if (Solve(board, 0))
        {
            Console.WriteLine($"{N}-Queens Solution:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(board[i, j] == 1 ? "Q " : ". ");
                Console.WriteLine();
            }
        }
    }
}
