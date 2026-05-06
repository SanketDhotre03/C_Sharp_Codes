// Program: CsvReader
// Difficulty: Medium
// Description: Parses CSV files manually without external libraries.
using System;
using System.Collections.Generic;
using System.IO;

class CsvReader
{
    static List<string[]> ParseCsv(string path, char delimiter = ',')
    {
        var rows = new List<string[]>();
        foreach (var line in File.ReadAllLines(path))
            rows.Add(line.Split(delimiter));
        return rows;
    }

    static void Main(string[] args)
    {
        string path = Path.Combine(Path.GetTempPath(), "data.csv");
        File.WriteAllText(path,
            "Name,Age,City\nAlice,30,London\nBob,25,Paris\nCharlie,35,Tokyo");

        var rows = ParseCsv(path);
        string[] headers = rows[0];
        Console.WriteLine("Headers: " + string.Join(" | ", headers));
        Console.WriteLine(new string('-', 30));
        for (int i = 1; i < rows.Count; i++)
        {
            for (int j = 0; j < headers.Length; j++)
                Console.Write($"{headers[j]}:{rows[i][j]}  ");
            Console.WriteLine();
        }

        File.Delete(path);
    }
}
