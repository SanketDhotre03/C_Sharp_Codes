using System;

class Program28
{
    static void Main()
    {
        int marks = 82;
        string grade = marks >= 90 ? "A" : marks >= 75 ? "B" : marks >= 60 ? "C" : "D";
        Console.WriteLine($"Grade: {grade}");
    }
}
