using System;
using System.Collections.Generic;

class Program39
{
    static void Main()
    {
        Stack<string> stack = new Stack<string>();
        stack.Push("A");
        stack.Push("B");
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Peek());
    }
}
