// Program: DisjointSet
// Difficulty: High
// Description: Union-Find data structure with path compression and union by rank.
using System;

class DisjointSet
{
    int[] parent, rank;

    DisjointSet(int n)
    {
        parent = new int[n]; rank = new int[n];
        for (int i = 0; i < n; i++) parent[i] = i;
    }

    int Find(int x)
    {
        if (parent[x] != x) parent[x] = Find(parent[x]);
        return parent[x];
    }

    void Union(int x, int y)
    {
        int px = Find(x), py = Find(y);
        if (px == py) return;
        if (rank[px] < rank[py]) (px, py) = (py, px);
        parent[py] = px;
        if (rank[px] == rank[py]) rank[px]++;
    }

    bool Connected(int x, int y) => Find(x) == Find(y);

    static void Main(string[] args)
    {
        var ds = new DisjointSet(7);
        ds.Union(1, 2); ds.Union(2, 3); ds.Union(4, 5);
        Console.WriteLine($"1-3 connected: {ds.Connected(1, 3)}");
        Console.WriteLine($"1-4 connected: {ds.Connected(1, 4)}");
        ds.Union(3, 4);
        Console.WriteLine($"1-5 connected: {ds.Connected(1, 5)}");
    }
}
