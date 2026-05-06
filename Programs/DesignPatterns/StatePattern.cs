// Program: StatePattern
// Difficulty: High
// Description: State pattern models objects that change behavior based on state.
using System;

interface IOrderState { void Next(Order order); void Cancel(Order order); string Status { get; } }

class PendingState : IOrderState
{
    public string Status => "Pending";
    public void Next(Order o)   { Console.WriteLine("Processing order..."); o.State = new ProcessingState(); }
    public void Cancel(Order o) { Console.WriteLine("Order cancelled."); o.State = new CancelledState(); }
}

class ProcessingState : IOrderState
{
    public string Status => "Processing";
    public void Next(Order o)   { Console.WriteLine("Order shipped!"); o.State = new ShippedState(); }
    public void Cancel(Order o) { Console.WriteLine("Order cancelled."); o.State = new CancelledState(); }
}

class ShippedState : IOrderState
{
    public string Status => "Shipped";
    public void Next(Order o)   { Console.WriteLine("Order delivered!"); o.State = new DeliveredState(); }
    public void Cancel(Order o) => Console.WriteLine("Cannot cancel shipped order.");
}

class DeliveredState : IOrderState
{
    public string Status => "Delivered";
    public void Next(Order o)   => Console.WriteLine("Order already delivered.");
    public void Cancel(Order o) => Console.WriteLine("Cannot cancel delivered order.");
}

class CancelledState : IOrderState
{
    public string Status => "Cancelled";
    public void Next(Order o)   => Console.WriteLine("Order is cancelled.");
    public void Cancel(Order o) => Console.WriteLine("Already cancelled.");
}

class Order
{
    public IOrderState State { get; set; } = new PendingState();
    public void Next()   { State.Next(this); Console.WriteLine($"  -> Status: {State.Status}"); }
    public void Cancel() { State.Cancel(this); Console.WriteLine($"  -> Status: {State.Status}"); }
}

class StatePattern
{
    static void Main(string[] args)
    {
        var order = new Order();
        Console.WriteLine($"Status: {order.State.Status}");
        order.Next(); order.Next(); order.Next();
    }
}
