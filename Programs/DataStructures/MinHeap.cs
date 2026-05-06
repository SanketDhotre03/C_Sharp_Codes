// Program: MinHeap
// Difficulty: Medium
// Description: Implements a min heap with insert and extract-min operations.
using System;
using System.Collections.Generic;

class MinHeap
{
    List<int> heap = new List<int>();

    void Insert(int val)
    {
        heap.Add(val);
        int i = heap.Count - 1;
        while (i > 0 && heap[(i - 1) / 2] > heap[i])
        {
            int p = (i - 1) / 2;
            (heap[p], heap[i]) = (heap[i], heap[p]);
            i = p;
        }
    }

    int ExtractMin()
    {
        int min = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        Heapify(0);
        return min;
    }

    void Heapify(int i)
    {
        int n = heap.Count, smallest = i, l = 2 * i + 1, r = 2 * i + 2;
        if (l < n && heap[l] < heap[smallest]) smallest = l;
        if (r < n && heap[r] < heap[smallest]) smallest = r;
        if (smallest != i) { (heap[i], heap[smallest]) = (heap[smallest], heap[i]); Heapify(smallest); }
    }

    static void Main(string[] args)
    {
        var mh = new MinHeap();
        int[] vals = { 5, 3, 8, 1, 4, 2 };
        foreach (int v in vals) mh.Insert(v);
        Console.Write("Min heap extraction: ");
        while (mh.heap.Count > 0) Console.Write(mh.ExtractMin() + " ");
        Console.WriteLine();
    }
}
