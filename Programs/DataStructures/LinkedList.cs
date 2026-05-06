// Program: LinkedList
// Difficulty: Medium
// Description: Implements a singly linked list with insert, delete, and display.
using System;

class LinkedList
{
    class Node { public int Data; public Node Next; }
    Node head;

    void Insert(int data)
    {
        Node newNode = new Node { Data = data };
        if (head == null) { head = newNode; return; }
        Node curr = head;
        while (curr.Next != null) curr = curr.Next;
        curr.Next = newNode;
    }

    void Delete(int data)
    {
        if (head == null) return;
        if (head.Data == data) { head = head.Next; return; }
        Node curr = head;
        while (curr.Next != null && curr.Next.Data != data) curr = curr.Next;
        if (curr.Next != null) curr.Next = curr.Next.Next;
    }

    void Display()
    {
        Node curr = head;
        while (curr != null) { Console.Write(curr.Data + " -> "); curr = curr.Next; }
        Console.WriteLine("null");
    }

    static void Main(string[] args)
    {
        var list = new LinkedList();
        list.Insert(10); list.Insert(20); list.Insert(30); list.Insert(40);
        list.Display();
        list.Delete(20);
        list.Display();
    }
}
