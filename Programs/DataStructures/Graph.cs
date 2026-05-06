// Program: Graph
// Difficulty: Medium
// Description: Graph with adjacency list, add edge, and display operations.
using System;
using System.Collections.Generic;

class Graph
{
    int V;
    List<int>[] adj;

    Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++) adj[i] = new List<int>();
    }

    void AddEdge(int u, int v) { adj[u].Add(v); adj[v].Add(u); }

    void Display()
    {
        for (int i = 0; i < V; i++)
            Console.WriteLine($"{i}: [{string.Join(", ", adj[i])}]");
    }

    static void Main(string[] args)
    {
        var g = new Graph(5);
        g.AddEdge(0, 1); g.AddEdge(0, 4); g.AddEdge(1, 2);
        g.AddEdge(1, 3); g.AddEdge(1, 4); g.AddEdge(2, 3); g.AddEdge(3, 4);
        Console.WriteLine("Adjacency List:");
        g.Display();
    }
}
