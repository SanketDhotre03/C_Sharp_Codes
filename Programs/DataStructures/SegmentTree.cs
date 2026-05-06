// Program: SegmentTree
// Difficulty: High
// Description: Segment tree for range sum queries and point updates.
// Complexity: O(log n) query/update
using System;

class SegmentTree
{
    int[] tree;
    int n;

    SegmentTree(int[] arr)
    {
        n = arr.Length;
        tree = new int[4 * n];
        Build(arr, 0, 0, n - 1);
    }

    void Build(int[] arr, int node, int start, int end)
    {
        if (start == end) { tree[node] = arr[start]; return; }
        int mid = (start + end) / 2;
        Build(arr, 2 * node + 1, start, mid);
        Build(arr, 2 * node + 2, mid + 1, end);
        tree[node] = tree[2 * node + 1] + tree[2 * node + 2];
    }

    int Query(int node, int start, int end, int l, int r)
    {
        if (r < start || end < l) return 0;
        if (l <= start && end <= r) return tree[node];
        int mid = (start + end) / 2;
        return Query(2 * node + 1, start, mid, l, r)
             + Query(2 * node + 2, mid + 1, end, l, r);
    }

    int Query(int l, int r) => Query(0, 0, n - 1, l, r);

    static void Main(string[] args)
    {
        int[] arr = { 1, 3, 5, 7, 9, 11 };
        var st = new SegmentTree(arr);
        Console.WriteLine($"Sum [1,3]: {st.Query(1, 3)}");  // 15
        Console.WriteLine($"Sum [0,5]: {st.Query(0, 5)}");  // 36
    }
}
