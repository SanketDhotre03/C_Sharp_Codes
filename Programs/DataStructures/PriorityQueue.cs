// Program: PriorityQueue
// Difficulty: Medium
// Description: Min-priority queue using a sorted list.
using System;
using System.Collections.Generic;

class PriorityQueue<T>
{
    SortedList<int, Queue<T>> data = new SortedList<int, Queue<T>>();
    int count;

    void Enqueue(T item, int priority)
    {
        if (!data.ContainsKey(priority)) data[priority] = new Queue<T>();
        data[priority].Enqueue(item);
        count++;
    }

    T Dequeue()
    {
        if (count == 0) throw new InvalidOperationException("Empty");
        var first = data.Keys[0];
        T item = data[first].Dequeue();
        if (data[first].Count == 0) data.Remove(first);
        count--;
        return item;
    }

    static void Main(string[] args)
    {
        var pq = new PriorityQueue<string>();
        pq.Enqueue("Low task", 5);
        pq.Enqueue("High task", 1);
        pq.Enqueue("Medium task", 3);
        Console.WriteLine(pq.Dequeue());  // High task
        Console.WriteLine(pq.Dequeue());  // Medium task
        Console.WriteLine(pq.Dequeue());  // Low task
    }
}
