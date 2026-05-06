// Program: CompositePattern
// Difficulty: High
// Description: Composite pattern for tree structures (file system example).
using System;
using System.Collections.Generic;

abstract class FileSystemItem
{
    public string Name { get; }
    protected FileSystemItem(string name) => Name = name;
    public abstract void Display(string indent = "");
    public abstract long Size { get; }
}

class File : FileSystemItem
{
    public File(string name, long size) : base(name) => Size = size;
    public override long Size { get; }
    public override void Display(string indent = "") =>
        Console.WriteLine($"{indent}📄 {Name} ({Size} bytes)");
}

class Directory : FileSystemItem
{
    List<FileSystemItem> children = new List<FileSystemItem>();
    public Directory(string name) : base(name) { }
    public void Add(FileSystemItem item) => children.Add(item);
    public override long Size => children.Sum(c => c.Size);
    public override void Display(string indent = "")
    {
        Console.WriteLine($"{indent}📁 {Name}/ ({Size} bytes)");
        foreach (var c in children) c.Display(indent + "  ");
    }
}

class CompositePattern
{
    static void Main(string[] args)
    {
        var root = new Directory("root");
        var src = new Directory("src");
        src.Add(new File("main.cs", 1200));
        src.Add(new File("utils.cs", 800));
        var docs = new Directory("docs");
        docs.Add(new File("readme.md", 500));
        root.Add(src); root.Add(docs);
        root.Add(new File("config.json", 200));
        root.Display();
    }
}
