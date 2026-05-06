// Program: FlyweightPattern
// Difficulty: High
// Description: Flyweight pattern to share common data and reduce memory usage.
using System;
using System.Collections.Generic;

class TreeType
{
    public string Name, Color, Texture;
    public TreeType(string name, string color, string texture)
    { Name = name; Color = color; Texture = texture; }
    public void Draw(int x, int y) =>
        Console.WriteLine($"Drawing {Name} [{Color},{Texture}] at ({x},{y})");
}

class TreeFactory
{
    static Dictionary<string, TreeType> types = new Dictionary<string, TreeType>();
    public static TreeType GetType(string name, string color, string texture)
    {
        string key = $"{name}_{color}_{texture}";
        if (!types.ContainsKey(key))
            types[key] = new TreeType(name, color, texture);
        return types[key];
    }
    public static int TypeCount => types.Count;
}

class Tree
{
    int x, y; TreeType type;
    public Tree(int x, int y, TreeType t) { this.x = x; this.y = y; type = t; }
    public void Draw() => type.Draw(x, y);
}

class FlyweightPattern
{
    static void Main(string[] args)
    {
        var trees = new List<Tree>();
        var oak   = TreeFactory.GetType("Oak",  "Green", "Rough");
        var pine  = TreeFactory.GetType("Pine", "Dark",  "Smooth");
        trees.Add(new Tree(1, 2, oak)); trees.Add(new Tree(3, 4, oak));
        trees.Add(new Tree(5, 6, pine)); trees.Add(new Tree(7, 8, oak));
        foreach (var t in trees) t.Draw();
        Console.WriteLine($"Unique tree types: {TreeFactory.TypeCount} (out of {trees.Count} trees)");
    }
}
