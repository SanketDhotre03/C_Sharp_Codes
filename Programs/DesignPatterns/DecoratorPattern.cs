// Program: DecoratorPattern
// Difficulty: High
// Description: Decorator pattern to add behaviors dynamically without subclassing.
using System;

interface ICoffee { string Description { get; } double Cost { get; } }

class SimpleCoffee : ICoffee
{
    public string Description => "Coffee";
    public double Cost => 1.0;
}

abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;
    protected CoffeeDecorator(ICoffee coffee) => _coffee = coffee;
    public virtual string Description => _coffee.Description;
    public virtual double Cost => _coffee.Cost;
}

class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee c) : base(c) { }
    public override string Description => _coffee.Description + ", Milk";
    public override double Cost => _coffee.Cost + 0.25;
}

class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee c) : base(c) { }
    public override string Description => _coffee.Description + ", Sugar";
    public override double Cost => _coffee.Cost + 0.10;
}

class VanillaDecorator : CoffeeDecorator
{
    public VanillaDecorator(ICoffee c) : base(c) { }
    public override string Description => _coffee.Description + ", Vanilla";
    public override double Cost => _coffee.Cost + 0.50;
}

class DecoratorPattern
{
    static void Main(string[] args)
    {
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.Description}: ${coffee.Cost}");

        coffee = new MilkDecorator(coffee);
        coffee = new SugarDecorator(coffee);
        coffee = new VanillaDecorator(coffee);
        Console.WriteLine($"{coffee.Description}: ${coffee.Cost}");
    }
}
