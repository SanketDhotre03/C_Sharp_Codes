using System;

namespace CSharpCodes
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Welcome to C# Codes Repository");
            
            // Example: Simple arithmetic
            int num1 = 10;
            int num2 = 20;
            int sum = num1 + num2;
            
            Console.WriteLine($"Sum of {num1} and {num2} is: {sum}");
            
            // Example: Loop
            Console.WriteLine("\nNumbers from 1 to 5:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Number: {i}");
            }
        }
    }
}