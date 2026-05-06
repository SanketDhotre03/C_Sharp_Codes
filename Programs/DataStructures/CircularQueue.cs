// Program: CircularQueue
// Difficulty: Medium
// Description: Fixed-size circular queue (ring buffer) implementation.
using System;

class CircularQueue
{
    int[] arr;
    int front, rear, size, capacity;

    CircularQueue(int cap)
    {
        capacity = cap;
        arr = new int[cap];
        front = rear = 0;
        size = 0;
    }

    bool Enqueue(int val)
    {
        if (size == capacity) return false;
        arr[rear] = val;
        rear = (rear + 1) % capacity;
        size++;
        return true;
    }

    int Dequeue()
    {
        if (size == 0) throw new Exception("Empty");
        int val = arr[front];
        front = (front + 1) % capacity;
        size--;
        return val;
    }

    static void Main(string[] args)
    {
        var cq = new CircularQueue(4);
        cq.Enqueue(1); cq.Enqueue(2); cq.Enqueue(3); cq.Enqueue(4);
        Console.WriteLine(cq.Enqueue(5)); // False - full
        Console.WriteLine(cq.Dequeue());  // 1
        cq.Enqueue(5);
        Console.WriteLine(cq.Dequeue());  // 2
    }
}
