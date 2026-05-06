using System;

class Program36
{
    static void Main()
    {
        DateTime birthDate = new DateTime(2000, 1, 1);
        int age = DateTime.Today.Year - birthDate.Year;
        if (birthDate.Date > DateTime.Today.AddYears(-age)) age--;
        Console.WriteLine($"Age is {age}");
    }
}
