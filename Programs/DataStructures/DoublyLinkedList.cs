// Program: DoublyLinkedList
// Difficulty: Medium
// Description: Implements a doubly linked list with forward and backward traversal.
using System;

class DoublyLinkedList
{
    class Node { public int Data; public Node Prev, Next; }
    Node head;

    void Insert(int data)
    {
        Node n = new Node { Data = data };
        if (head == null) { head = n; return; }
        Node curr = head;
        while (curr.Next != null) curr = curr.Next;
        curr.Next = n; n.Prev = curr;
    }

    void DisplayForward()
    {
        Node curr = head;
        Console.Write("Forward: ");
        while (curr != null) { Console.Write(curr.Data + " "); curr = curr.Next; }
        Console.WriteLine();
    }

    void DisplayBackward()
    {
        Node curr = head;
        while (curr.Next != null) curr = curr.Next;
        Console.Write("Backward: ");
        while (curr != null) { Console.Write(curr.Data + " "); curr = curr.Prev; }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        var list = new DoublyLinkedList();
        list.Insert(1); list.Insert(2); list.Insert(3); list.Insert(4);
        list.DisplayForward();
        list.DisplayBackward();
    }
}
