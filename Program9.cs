using System;

class Program9
{
    static void Main()
    {
        int number = 29;
        bool isPrime = number > 1;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0) isPrime = false;
        }
        Console.WriteLine(isPrime ? "Prime" : "Not Prime");
    }
}
