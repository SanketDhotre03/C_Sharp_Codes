// Program: DequeImplementation
// Difficulty: Medium
// Description: Double-ended queue (deque) implementation.
using System;
using System.Collections.Generic;

class DequeImplementation
{
    LinkedList<int> list = new LinkedList<int>();

    void AddFront(int val) => list.AddFirst(val);
    void AddBack(int val)  => list.AddLast(val);
    int RemoveFront() { var v = list.First.Value; list.RemoveFirst(); return v; }
    int RemoveBack()  { var v = list.Last.Value; list.RemoveLast(); return v; }
    int PeekFront() => list.First.Value;
    int PeekBack()  => list.Last.Value;
    int Count() => list.Count;

    static void Main(string[] args)
    {
        var dq = new DequeImplementation();
        dq.AddBack(1); dq.AddBack(2); dq.AddFront(0);
        Console.WriteLine($"Front: {dq.PeekFront()}, Back: {dq.PeekBack()}");
        Console.WriteLine($"Remove front: {dq.RemoveFront()}");
        Console.WriteLine($"Remove back: {dq.RemoveBack()}");
    }
}
