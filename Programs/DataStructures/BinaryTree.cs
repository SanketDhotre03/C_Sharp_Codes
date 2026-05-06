// Program: BinaryTree
// Difficulty: Medium
// Description: Implements a binary tree with in-order, pre-order, post-order traversals.
using System;

class BinaryTree
{
    class Node { public int Data; public Node Left, Right; }
    Node root;

    void Insert(int data)
    {
        root = InsertRec(root, data);
    }

    Node InsertRec(Node node, int data)
    {
        if (node == null) return new Node { Data = data };
        if (data < node.Data) node.Left = InsertRec(node.Left, data);
        else node.Right = InsertRec(node.Right, data);
        return node;
    }

    void InOrder(Node node) { if (node == null) return; InOrder(node.Left); Console.Write(node.Data + " "); InOrder(node.Right); }
    void PreOrder(Node node) { if (node == null) return; Console.Write(node.Data + " "); PreOrder(node.Left); PreOrder(node.Right); }
    void PostOrder(Node node) { if (node == null) return; PostOrder(node.Left); PostOrder(node.Right); Console.Write(node.Data + " "); }

    static void Main(string[] args)
    {
        var tree = new BinaryTree();
        int[] vals = { 5, 3, 7, 1, 4, 6, 8 };
        foreach (int v in vals) tree.Insert(v);
        Console.Write("InOrder:   "); tree.InOrder(tree.root); Console.WriteLine();
        Console.Write("PreOrder:  "); tree.PreOrder(tree.root); Console.WriteLine();
        Console.Write("PostOrder: "); tree.PostOrder(tree.root); Console.WriteLine();
    }
}
