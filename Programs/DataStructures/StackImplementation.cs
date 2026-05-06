// Program: StackImplementation
// Difficulty: Medium
// Description: Generic stack implementation using a linked list.
using System;

class StackImplementation<T>
{
    class Node { public T Data; public Node Next; }
    Node top;
    int count;

    void Push(T data)
    {
        top = new Node { Data = data, Next = top };
        count++;
    }

    T Pop()
    {
        if (top == null) throw new InvalidOperationException("Stack underflow");
        T data = top.Data; top = top.Next; count--;
        return data;
    }

    T Peek() => top == null ? throw new InvalidOperationException("Empty stack") : top.Data;
    bool IsEmpty() => top == null;
    int Count() => count;

    static void Main(string[] args)
    {
        var stack = new StackImplementation<int>();
        stack.Push(10); stack.Push(20); stack.Push(30);
        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Count: {stack.Count()}");
    }
}
