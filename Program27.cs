using System;

class Program27
{
    static void Main()
    {
        int choice = 1;
        double area = 0;

        switch (choice)
        {
            case 1:
                area = Math.PI * 5 * 5;
                break;
            case 2:
                area = 8 * 4;
                break;
            case 3:
                area = 0.5 * 10 * 6;
                break;
        }

        Console.WriteLine($"Area: {area:F2}");
    }
}
