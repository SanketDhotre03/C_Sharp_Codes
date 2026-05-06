using System;
using System.Collections.Generic;

class Program40
{
    static void Main()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Peek());
    }
}
