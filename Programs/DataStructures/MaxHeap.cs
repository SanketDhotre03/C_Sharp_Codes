// Program: MaxHeap
// Difficulty: Medium
// Description: Implements a max heap with insert and extract-max operations.
using System;
using System.Collections.Generic;

class MaxHeap
{
    List<int> heap = new List<int>();

    void Insert(int val)
    {
        heap.Add(val);
        int i = heap.Count - 1;
        while (i > 0 && heap[(i - 1) / 2] < heap[i])
        {
            int p = (i - 1) / 2;
            (heap[p], heap[i]) = (heap[i], heap[p]);
            i = p;
        }
    }

    int ExtractMax()
    {
        int max = heap[0];
        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        Heapify(0);
        return max;
    }

    void Heapify(int i)
    {
        int n = heap.Count, largest = i, l = 2 * i + 1, r = 2 * i + 2;
        if (l < n && heap[l] > heap[largest]) largest = l;
        if (r < n && heap[r] > heap[largest]) largest = r;
        if (largest != i) { (heap[i], heap[largest]) = (heap[largest], heap[i]); Heapify(largest); }
    }

    static void Main(string[] args)
    {
        var mh = new MaxHeap();
        int[] vals = { 3, 1, 6, 5, 2, 4 };
        foreach (int v in vals) mh.Insert(v);
        Console.Write("Extracted in order: ");
        while (mh.heap.Count > 0) Console.Write(mh.ExtractMax() + " ");
        Console.WriteLine();
    }
}
