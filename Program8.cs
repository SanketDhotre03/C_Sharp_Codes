using System;

class Program8
{
    static void Main()
    {
        int n = 8, a = 0, b = 1;
        Console.WriteLine("Fibonacci series:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(a + " ");
            int next = a + b;
            a = b;
            b = next;
        }
    }
}
