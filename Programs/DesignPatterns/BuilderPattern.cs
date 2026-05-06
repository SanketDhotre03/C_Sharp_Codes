// Program: BuilderPattern
// Difficulty: Medium
// Description: Builder pattern for constructing complex objects step by step.
using System;

class Pizza
{
    public string Size     { get; set; }
    public string Crust    { get; set; }
    public string Sauce    { get; set; }
    public string Cheese   { get; set; }
    public string Toppings { get; set; }

    public override string ToString() =>
        $"Pizza[{Size}, {Crust} crust, {Sauce} sauce, {Cheese}, {Toppings}]";
}

class PizzaBuilder
{
    private Pizza _pizza = new Pizza();
    public PizzaBuilder Size(string size)     { _pizza.Size = size; return this; }
    public PizzaBuilder Crust(string crust)   { _pizza.Crust = crust; return this; }
    public PizzaBuilder Sauce(string sauce)   { _pizza.Sauce = sauce; return this; }
    public PizzaBuilder Cheese(string cheese) { _pizza.Cheese = cheese; return this; }
    public PizzaBuilder Toppings(string tops) { _pizza.Toppings = tops; return this; }
    public Pizza Build() => _pizza;
}

class BuilderPattern
{
    static void Main(string[] args)
    {
        var pizza = new PizzaBuilder()
            .Size("Large")
            .Crust("Thin")
            .Sauce("Tomato")
            .Cheese("Mozzarella")
            .Toppings("Mushrooms, Peppers")
            .Build();
        Console.WriteLine(pizza);
    }
}
