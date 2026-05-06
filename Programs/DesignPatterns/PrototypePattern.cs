// Program: PrototypePattern
// Difficulty: Medium
// Description: Prototype pattern using ICloneable for object copying.
using System;

class Document : ICloneable
{
    public string Title    { get; set; }
    public string Content  { get; set; }
    public string Author   { get; set; }
    public DateTime Created { get; private set; } = DateTime.Now;

    public Document(string title, string content, string author)
    {
        Title = title; Content = content; Author = author;
    }

    public object Clone() => new Document(Title, Content, Author) { Created = Created };
    public override string ToString() => $"[{Author}] {Title}: {Content[..Math.Min(20, Content.Length)]}...";
}

class PrototypePattern
{
    static void Main(string[] args)
    {
        var original = new Document("Report", "This is the original content.", "Alice");
        var copy = (Document)original.Clone();
        copy.Title = "Report (Copy)";
        copy.Author = "Bob";
        Console.WriteLine("Original: " + original);
        Console.WriteLine("Copy:     " + copy);
        Console.WriteLine($"Same object: {ReferenceEquals(original, copy)}");
    }
}
