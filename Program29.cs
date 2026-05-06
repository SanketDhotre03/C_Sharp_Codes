using System;

class Program29
{
    static void Main()
    {
        int day = 3;
        string name = day switch
        {
            1 => "Monday",
            2 => "Tuesday",
            3 => "Wednesday",
            4 => "Thursday",
            5 => "Friday",
            6 => "Saturday",
            7 => "Sunday",
            _ => "Invalid"
        };
        Console.WriteLine(name);
    }
}
