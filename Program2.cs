using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Enter an integer:");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number % 2 == 0) {
            Console.WriteLine("{0} is even.", number);
        } else {
            Console.WriteLine("{0} is odd.", number);
        }
    }
}