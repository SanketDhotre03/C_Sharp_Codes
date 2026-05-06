// Program: CovariantContravariant
// Difficulty: High
// Description: Demonstrates covariance and contravariance with generic interfaces.
using System;
using System.Collections.Generic;

interface IProducer<out T>  { T Produce(); }
interface IConsumer<in T>   { void Consume(T item); }

class AnimalProducer : IProducer<string>
{
    public string Produce() => "Generic Animal";
}

class Printer<T> : IConsumer<T>
{
    public void Consume(T item) => Console.WriteLine($"Printing: {item}");
}

class CovariantContravariant
{
    static void Main(string[] args)
    {
        IProducer<string> strProducer = new AnimalProducer();
        IProducer<object> objProducer = strProducer; // covariance: string -> object
        Console.WriteLine(objProducer.Produce());

        IConsumer<object> objConsumer = new Printer<object>();
        IConsumer<string> strConsumer = objConsumer; // contravariance: object -> string
        strConsumer.Consume("Hello, contravariance!");

        IEnumerable<string> strings = new List<string> { "a", "b", "c" };
        IEnumerable<object> objects = strings; // IEnumerable<out T> is covariant
        foreach (var o in objects) Console.Write(o + " ");
        Console.WriteLine();
    }
}
