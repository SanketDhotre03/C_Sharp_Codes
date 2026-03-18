using System;

class Program43
{
    static void Main()
    {
        Func<int, int, int> add = (a, b) => a + b;
        Action<string> show = message => Console.WriteLine(message);
        show($"Result: {add(7, 8)}");
    }
}
