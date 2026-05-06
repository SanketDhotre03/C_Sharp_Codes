// Program: PropertyAccessors
// Difficulty: Medium
// Description: Demonstrates property accessors, auto-properties, and computed properties.
using System;

class Temperature
{
    private double celsius;
    public double Celsius
    {
        get => celsius;
        set => celsius = value < -273.15 ? throw new ArgumentException("Below absolute zero") : value;
    }
    public double Fahrenheit
    {
        get => celsius * 9 / 5 + 32;
        set => Celsius = (value - 32) * 5 / 9;
    }
    public double Kelvin
    {
        get => celsius + 273.15;
        set => Celsius = value - 273.15;
    }
    public string State => celsius > 100 ? "Gas" : celsius >= 0 ? "Liquid" : "Solid";
}

class PropertyAccessors
{
    static void Main(string[] args)
    {
        var temp = new Temperature { Celsius = 25 };
        Console.WriteLine($"{temp.Celsius}°C = {temp.Fahrenheit}°F = {temp.Kelvin}K [{temp.State}]");
        temp.Fahrenheit = 212;
        Console.WriteLine($"{temp.Celsius}°C = {temp.Fahrenheit}°F [{temp.State}]");
    }
}
