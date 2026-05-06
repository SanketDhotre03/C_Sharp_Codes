// Program: AnagramCheck
// Difficulty: Medium
// Description: Checks if two strings are anagrams of each other.
// Complexity: O(n log n) time
using System;

class AnagramCheck
{
    static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        char[] a = s.ToLower().ToCharArray();
        char[] b = t.ToLower().ToCharArray();
        Array.Sort(a); Array.Sort(b);
        return new string(a) == new string(b);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(IsAnagram("listen", "silent"));   // True
        Console.WriteLine(IsAnagram("hello", "world"));     // False
        Console.WriteLine(IsAnagram("Triangle", "Integral")); // True
    }
}
