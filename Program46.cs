using System;

abstract class Animal
{
    public abstract void Sound();
}

class Dog : Animal
{
    public override void Sound() => Console.WriteLine("Dog barks");
}

class Program46
{
    static void Main()
    {
        Animal animal = new Dog();
        animal.Sound();
    }
}
