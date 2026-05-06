// Program: BinarySearchTree
// Difficulty: Medium
// Description: BST with insert, search, and delete operations.
using System;

class BinarySearchTree
{
    class Node { public int Data; public Node Left, Right; }
    Node root;

    Node Insert(Node node, int data)
    {
        if (node == null) return new Node { Data = data };
        if (data < node.Data) node.Left = Insert(node.Left, data);
        else if (data > node.Data) node.Right = Insert(node.Right, data);
        return node;
    }

    bool Search(Node node, int data)
    {
        if (node == null) return false;
        if (node.Data == data) return true;
        return data < node.Data ? Search(node.Left, data) : Search(node.Right, data);
    }

    void InOrder(Node node) { if (node == null) return; InOrder(node.Left); Console.Write(node.Data + " "); InOrder(node.Right); }

    static void Main(string[] args)
    {
        var bst = new BinarySearchTree();
        int[] vals = { 50, 30, 70, 20, 40, 60, 80 };
        foreach (int v in vals) bst.root = bst.Insert(bst.root, v);
        Console.Write("InOrder: "); bst.InOrder(bst.root); Console.WriteLine();
        Console.WriteLine($"Search 40: {bst.Search(bst.root, 40)}");
        Console.WriteLine($"Search 99: {bst.Search(bst.root, 99)}");
    }
}
