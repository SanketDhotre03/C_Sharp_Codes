// Program: EventsAndDelegates
// Difficulty: Medium
// Description: Demonstrates delegates, events, and event handlers.
using System;

class TemperatureSensor
{
    public delegate void TemperatureChangedHandler(double oldTemp, double newTemp);
    public event TemperatureChangedHandler TemperatureChanged;
    public event Action<string> AlertRaised;

    private double _temperature;
    public double Temperature
    {
        get => _temperature;
        set
        {
            double old = _temperature;
            _temperature = value;
            TemperatureChanged?.Invoke(old, value);
            if (value > 100) AlertRaised?.Invoke($"CRITICAL: {value}°C exceeds 100°C!");
        }
    }
}

class EventsAndDelegates
{
    static void Main(string[] args)
    {
        var sensor = new TemperatureSensor();
        sensor.TemperatureChanged += (old, now) =>
            Console.WriteLine($"Temp changed: {old}°C -> {now}°C");
        sensor.AlertRaised += msg => Console.WriteLine($"[ALERT] {msg}");

        sensor.Temperature = 25.0;
        sensor.Temperature = 75.0;
        sensor.Temperature = 105.0;
    }
}
