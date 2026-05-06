// Program: PalindromeCheck
// Difficulty: Medium
// Description: Checks if a string is a palindrome ignoring spaces and case.
// Complexity: O(n) time
using System;

class PalindromeCheck
{
    static bool IsPalindrome(string s)
    {
        s = s.Replace(" ", "").ToLower();
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            if (s[left] != s[right]) return false;
            left++; right--;
        }
        return true;
    }

    static void Main(string[] args)
    {
        string[] tests = { "racecar", "A man a plan a canal Panama", "hello" };
        foreach (var t in tests)
            Console.WriteLine($"'{t}' -> {IsPalindrome(t)}");
    }
}
