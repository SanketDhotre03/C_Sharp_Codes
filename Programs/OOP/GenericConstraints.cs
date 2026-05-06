// Program: GenericConstraints
// Difficulty: Medium
// Description: Demonstrates generic type constraints in C#.
using System;
using System.Collections.Generic;

interface IHasName { string Name { get; } }

class Repository<T> where T : class, IHasName, new()
{
    List<T> items = new List<T>();
    public void Add(T item) => items.Add(item);
    public T Find(string name) => items.Find(i => i.Name == name);
    public void PrintAll() => items.ForEach(i => Console.WriteLine(i.Name));
}

class Product : IHasName
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Product() { }
    public Product(string name, decimal price) { Name = name; Price = price; }
}

class GenericConstraints
{
    static T CreateAndInit<T>(Action<T> init) where T : new()
    {
        var obj = new T();
        init(obj);
        return obj;
    }

    static void Main(string[] args)
    {
        var repo = new Repository<Product>();
        repo.Add(new Product("Laptop", 999.99m));
        repo.Add(new Product("Phone", 599.99m));
        repo.PrintAll();
        var found = repo.Find("Phone");
        Console.WriteLine($"Found: {found?.Name} at ${found?.Price}");

        var p = CreateAndInit<Product>(x => { x.Name = "Tablet"; x.Price = 299m; });
        Console.WriteLine($"Created: {p.Name}");
    }
}
