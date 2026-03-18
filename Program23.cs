using System;

class Program23
{
    static void Main()
    {
        string a = "listen", b = "silent";
        char[] arrA = a.ToCharArray();
        char[] arrB = b.ToCharArray();
        Array.Sort(arrA);
        Array.Sort(arrB);
        Console.WriteLine(new string(arrA) == new string(arrB) ? "Anagram" : "Not Anagram");
    }
}
