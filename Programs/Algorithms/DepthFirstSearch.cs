// Program: DepthFirstSearch
// Difficulty: Medium
// Description: DFS traversal of a graph represented as adjacency list.
// Complexity: O(V + E) time
using System;
using System.Collections.Generic;

class DepthFirstSearch
{
    static void DFS(Dictionary<int, List<int>> graph, int node, HashSet<int> visited)
    {
        visited.Add(node);
        Console.Write(node + " ");
        foreach (int neighbor in graph[node])
            if (!visited.Contains(neighbor))
                DFS(graph, neighbor, visited);
    }

    static void Main(string[] args)
    {
        var graph = new Dictionary<int, List<int>>
        {
            {0, new List<int>{1, 2}},
            {1, new List<int>{0, 3, 4}},
            {2, new List<int>{0, 5}},
            {3, new List<int>{1}},
            {4, new List<int>{1}},
            {5, new List<int>{2}}
        };
        Console.Write("DFS from 0: ");
        DFS(graph, 0, new HashSet<int>());
        Console.WriteLine();
    }
}
