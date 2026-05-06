// Program: InheritanceMultiLevel
// Difficulty: Medium
// Description: Demonstrates multi-level inheritance chain.
using System;

class Vehicle
{
    public int Speed { get; protected set; }
    public virtual void Drive() => Console.WriteLine($"Vehicle driving at {Speed} km/h");
}

class Car : Vehicle
{
    public string Brand { get; set; }
    public Car(string brand) { Brand = brand; Speed = 120; }
    public override void Drive() => Console.WriteLine($"{Brand} car driving at {Speed} km/h");
}

class ElectricCar : Car
{
    public int BatteryLevel { get; set; }
    public ElectricCar(string brand, int battery) : base(brand) { BatteryLevel = battery; Speed = 150; }
    public override void Drive() => Console.WriteLine($"{Brand} electric car (battery:{BatteryLevel}%) driving at {Speed} km/h");
    public void Charge() => Console.WriteLine($"Charging {Brand}...");
}

class InheritanceMultiLevel
{
    static void Main(string[] args)
    {
        var ec = new ElectricCar("Tesla", 80);
        ec.Drive();
        ec.Charge();
        Car car = ec;
        car.Drive();
    }
}
