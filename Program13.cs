using System;

class Program13
{
    static void Main()
    {
        string text = "level";
        char[] chars = text.ToCharArray();
        Array.Reverse(chars);
        string reversed = new string(chars);
        Console.WriteLine(text == reversed ? "Palindrome" : "Not Palindrome");
    }
}
