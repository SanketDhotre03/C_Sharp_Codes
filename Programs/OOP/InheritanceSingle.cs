// Program: InheritanceSingle
// Difficulty: Medium
// Description: Demonstrates single-level inheritance in C#.
using System;

class Animal
{
    public string Name { get; set; }
    public Animal(string name) => Name = name;
    public virtual void Speak() => Console.WriteLine($"{Name} makes a sound");
    public void Eat() => Console.WriteLine($"{Name} is eating");
}

class Dog : Animal
{
    public string Breed { get; set; }
    public Dog(string name, string breed) : base(name) => Breed = breed;
    public override void Speak() => Console.WriteLine($"{Name} barks: Woof!");
    public void Fetch() => Console.WriteLine($"{Name} fetches the ball");
}

class InheritanceSingle
{
    static void Main(string[] args)
    {
        var dog = new Dog("Rex", "German Shepherd");
        dog.Speak();
        dog.Eat();
        dog.Fetch();
        Console.WriteLine($"Breed: {dog.Breed}");
        Animal animal = dog; // polymorphic reference
        animal.Speak();
    }
}
