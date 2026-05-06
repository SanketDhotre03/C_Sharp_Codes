// Program: SealedClass
// Difficulty: Medium
// Description: Shows sealed classes and methods that cannot be overridden or inherited.
using System;

class Base
{
    public virtual void Method1() => Console.WriteLine("Base.Method1");
    public virtual void Method2() => Console.WriteLine("Base.Method2");
}

class Middle : Base
{
    public override void Method1() => Console.WriteLine("Middle.Method1");
    public sealed override void Method2() => Console.WriteLine("Middle.Method2 (sealed)");
}

sealed class Leaf : Middle
{
    public override void Method1() => Console.WriteLine("Leaf.Method1");
    // Cannot override Method2 - it's sealed in Middle
    public void NewMethod() => Console.WriteLine("Leaf.NewMethod");
}

class SealedClass
{
    static void Main(string[] args)
    {
        Base b = new Leaf();
        b.Method1(); // Leaf.Method1
        b.Method2(); // Middle.Method2 (sealed)

        var leaf = new Leaf();
        leaf.NewMethod();
    }
}
