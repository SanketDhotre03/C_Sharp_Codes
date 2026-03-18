using System;

class Program34
{
    static void Main()
    {
        try
        {
            int a = 10, b = 0;
            Console.WriteLine(a / b);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Handled error: " + ex.Message);
        }
    }
}
