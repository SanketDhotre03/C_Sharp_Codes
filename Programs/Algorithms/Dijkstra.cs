// Program: Dijkstra
// Difficulty: High
// Description: Finds shortest paths from a source vertex using Dijkstra's algorithm.
// Complexity: O((V + E) log V) with priority queue
using System;
using System.Collections.Generic;

class Dijkstra
{
    static int[] ShortestPath(int[,] graph, int src, int V)
    {
        int[] dist = new int[V];
        bool[] visited = new bool[V];
        for (int i = 0; i < V; i++) dist[i] = int.MaxValue;
        dist[src] = 0;
        for (int count = 0; count < V - 1; count++)
        {
            int u = -1;
            for (int v = 0; v < V; v++)
                if (!visited[v] && (u == -1 || dist[v] < dist[u])) u = v;
            visited[u] = true;
            for (int v = 0; v < V; v++)
                if (!visited[v] && graph[u, v] != 0 && dist[u] != int.MaxValue
                    && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];
        }
        return dist;
    }

    static void Main(string[] args)
    {
        int[,] graph = {
            {0, 4, 0, 0, 0, 0, 0, 8, 0},
            {4, 0, 8, 0, 0, 0, 0,11, 0},
            {0, 8, 0, 7, 0, 4, 0, 0, 2},
            {0, 0, 7, 0, 9,14, 0, 0, 0},
            {0, 0, 0, 9, 0,10, 0, 0, 0},
            {0, 0, 4,14,10, 0, 2, 0, 0},
            {0, 0, 0, 0, 0, 2, 0, 1, 6},
            {8,11, 0, 0, 0, 0, 1, 0, 7},
            {0, 0, 2, 0, 0, 0, 6, 7, 0}
        };
        int[] dist = ShortestPath(graph, 0, 9);
        Console.WriteLine("Vertex	Distance from Source");
        for (int i = 0; i < 9; i++)
            Console.WriteLine($"{i}	{dist[i]}");
    }
}
