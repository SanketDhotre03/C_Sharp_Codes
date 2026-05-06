// Program: AVLTree
// Difficulty: High
// Description: Self-balancing AVL tree with rotations.
using System;

class AVLTree
{
    class Node { public int Data, Height; public Node Left, Right; }

    int Height(Node n) => n == null ? 0 : n.Height;
    int GetBalance(Node n) => n == null ? 0 : Height(n.Left) - Height(n.Right);

    Node RightRotate(Node y)
    {
        Node x = y.Left, T2 = x.Right;
        x.Right = y; y.Left = T2;
        y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
        x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
        return x;
    }

    Node LeftRotate(Node x)
    {
        Node y = x.Right, T2 = y.Left;
        y.Left = x; x.Right = T2;
        x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
        y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
        return y;
    }

    Node Insert(Node node, int data)
    {
        if (node == null) return new Node { Data = data, Height = 1 };
        if (data < node.Data) node.Left = Insert(node.Left, data);
        else if (data > node.Data) node.Right = Insert(node.Right, data);
        else return node;
        node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        int balance = GetBalance(node);
        if (balance > 1 && data < node.Left.Data) return RightRotate(node);
        if (balance < -1 && data > node.Right.Data) return LeftRotate(node);
        if (balance > 1 && data > node.Left.Data) { node.Left = LeftRotate(node.Left); return RightRotate(node); }
        if (balance < -1 && data < node.Right.Data) { node.Right = RightRotate(node.Right); return LeftRotate(node); }
        return node;
    }

    void InOrder(Node node) { if (node == null) return; InOrder(node.Left); Console.Write(node.Data + " "); InOrder(node.Right); }

    static void Main(string[] args)
    {
        var tree = new AVLTree();
        Node root = null;
        int[] vals = { 10, 20, 30, 40, 50, 25 };
        foreach (int v in vals) root = tree.Insert(root, v);
        Console.Write("AVL InOrder: "); tree.InOrder(root); Console.WriteLine();
    }
}
