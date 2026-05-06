// Program: ObserverPattern
// Difficulty: Medium
// Description: Observer pattern for event-driven programming (pub/sub).
using System;
using System.Collections.Generic;

interface IObserver<T> { void Update(T data); }

class EventChannel<T>
{
    List<IObserver<T>> _observers = new List<IObserver<T>>();
    public void Subscribe(IObserver<T> o) => _observers.Add(o);
    public void Unsubscribe(IObserver<T> o) => _observers.Remove(o);
    public void Publish(T data) => _observers.ForEach(o => o.Update(data));
}

class StockPrice { public string Symbol; public double Price; }

class StockDashboard : IObserver<StockPrice>
{
    public void Update(StockPrice s) =>
        Console.WriteLine($"[Dashboard] {s.Symbol}: ${s.Price:F2}");
}

class StockAlert : IObserver<StockPrice>
{
    double threshold;
    public StockAlert(double threshold) => this.threshold = threshold;
    public void Update(StockPrice s)
    {
        if (s.Price > threshold)
            Console.WriteLine($"[Alert] {s.Symbol} above ${threshold}: ${s.Price:F2}");
    }
}

class ObserverPattern
{
    static void Main(string[] args)
    {
        var channel = new EventChannel<StockPrice>();
        channel.Subscribe(new StockDashboard());
        channel.Subscribe(new StockAlert(150));
        channel.Publish(new StockPrice { Symbol = "AAPL", Price = 145.30 });
        channel.Publish(new StockPrice { Symbol = "AAPL", Price = 155.00 });
    }
}
