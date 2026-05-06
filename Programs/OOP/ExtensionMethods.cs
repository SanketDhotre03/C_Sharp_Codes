// Program: ExtensionMethods
// Difficulty: Medium
// Description: Adds new methods to existing types using extension methods.
using System;
using System.Collections.Generic;
using System.Linq;

static class StringExtensions
{
    public static bool IsPalindrome(this string s) {
        s = s.ToLower().Replace(" ", "");
        return s == new string(s.Reverse().ToArray());
    }
    public static string Truncate(this string s, int maxLength) =>
        s.Length <= maxLength ? s : s[..maxLength] + "...";
    public static int WordCount(this string s) =>
        s.Split(new[] { ' ', '	', '
' }, StringSplitOptions.RemoveEmptyEntries).Length;
}

static class IntExtensions
{
    public static bool IsEven(this int n) => n % 2 == 0;
    public static IEnumerable<int> Times(this int n) => Enumerable.Range(0, n);
}

class ExtensionMethods
{
    static void Main(string[] args)
    {
        Console.WriteLine("racecar".IsPalindrome());
        Console.WriteLine("hello world".Truncate(7));
        Console.WriteLine("The quick brown fox".WordCount());
        Console.WriteLine(4.IsEven());
        Console.Write("Repeat 3x: ");
        foreach (var i in 3.Times()) Console.Write(i + " ");
        Console.WriteLine();
    }
}
