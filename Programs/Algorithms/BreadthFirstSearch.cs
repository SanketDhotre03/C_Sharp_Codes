// Program: BreadthFirstSearch
// Difficulty: Medium
// Description: BFS traversal of a graph represented as adjacency list.
// Complexity: O(V + E) time
using System;
using System.Collections.Generic;

class BreadthFirstSearch
{
    static void BFS(Dictionary<int, List<int>> graph, int start)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(start);
        visited.Add(start);
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            Console.Write(node + " ");
            foreach (int neighbor in graph[node])
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
        }
        Console.WriteLine();
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
        Console.Write("BFS from 0: ");
        BFS(graph, 0);
    }
}
