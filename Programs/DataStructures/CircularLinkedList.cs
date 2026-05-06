// Program: CircularLinkedList
// Difficulty: Medium
// Description: Implements a circular linked list with insert and traversal.
using System;

class CircularLinkedList
{
    class Node { public int Data; public Node Next; }
    Node head;

    void Insert(int data)
    {
        Node newNode = new Node { Data = data };
        if (head == null) { head = newNode; head.Next = head; return; }
        Node curr = head;
        while (curr.Next != head) curr = curr.Next;
        curr.Next = newNode; newNode.Next = head;
    }

    void Display(int count = 10)
    {
        if (head == null) return;
        Node curr = head;
        int i = 0;
        do { Console.Write(curr.Data + " -> "); curr = curr.Next; i++; }
        while (curr != head && i < count);
        Console.WriteLine("(circular)");
    }

    static void Main(string[] args)
    {
        var list = new CircularLinkedList();
        list.Insert(1); list.Insert(2); list.Insert(3); list.Insert(4);
        list.Display();
    }
}
