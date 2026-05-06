// Program: FenwickTree
// Difficulty: High
// Description: Binary Indexed Tree (Fenwick Tree) for prefix sum queries.
// Complexity: O(log n) per query/update
using System;

class FenwickTree
{
    int[] bit;
    int n;

    FenwickTree(int n)
    {
        this.n = n;
        bit = new int[n + 1];
    }

    void Update(int i, int delta)
    {
        for (++i; i <= n; i += i & (-i))
            bit[i] += delta;
    }

    int Query(int i)
    {
        int sum = 0;
        for (++i; i > 0; i -= i & (-i))
            sum += bit[i];
        return sum;
    }

    int RangeQuery(int l, int r) => Query(r) - (l > 0 ? Query(l - 1) : 0);

    static void Main(string[] args)
    {
        int[] arr = { 2, 1, 1, 3, 2, 3, 4, 5, 6, 7 };
        var ft = new FenwickTree(arr.Length);
        for (int i = 0; i < arr.Length; i++) ft.Update(i, arr[i]);
        Console.WriteLine($"Prefix sum [0,4]: {ft.RangeQuery(0, 4)}");  // 9
        Console.WriteLine($"Prefix sum [3,7]: {ft.RangeQuery(3, 7)}");  // 23
    }
}
