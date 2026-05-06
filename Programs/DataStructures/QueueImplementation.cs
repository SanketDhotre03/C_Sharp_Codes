// Program: QueueImplementation
// Difficulty: Medium
// Description: Generic queue implementation using a linked list.
using System;

class QueueImplementation<T>
{
    class Node { public T Data; public Node Next; }
    Node front, rear;
    int count;

    void Enqueue(T data)
    {
        var node = new Node { Data = data };
        if (rear == null) { front = rear = node; }
        else { rear.Next = node; rear = node; }
        count++;
    }

    T Dequeue()
    {
        if (front == null) throw new InvalidOperationException("Queue empty");
        T data = front.Data; front = front.Next;
        if (front == null) rear = null;
        count--;
        return data;
    }

    static void Main(string[] args)
    {
        var q = new QueueImplementation<string>();
        q.Enqueue("Alice"); q.Enqueue("Bob"); q.Enqueue("Charlie");
        Console.WriteLine(q.Dequeue());
        Console.WriteLine(q.Dequeue());
    }
}
