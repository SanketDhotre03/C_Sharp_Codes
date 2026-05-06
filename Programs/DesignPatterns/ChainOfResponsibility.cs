// Program: ChainOfResponsibility
// Difficulty: High
// Description: Chain of Responsibility passes a request through a chain of handlers.
using System;

abstract class ApprovalHandler
{
    protected ApprovalHandler next;
    public ApprovalHandler SetNext(ApprovalHandler handler) { next = handler; return handler; }
    public abstract void Handle(double amount);
}

class TeamLead : ApprovalHandler
{
    public override void Handle(double amount)
    {
        if (amount <= 1000) Console.WriteLine($"Team Lead approved ${amount}");
        else next?.Handle(amount);
    }
}

class Manager : ApprovalHandler
{
    public override void Handle(double amount)
    {
        if (amount <= 10000) Console.WriteLine($"Manager approved ${amount}");
        else next?.Handle(amount);
    }
}

class Director : ApprovalHandler
{
    public override void Handle(double amount)
    {
        if (amount <= 100000) Console.WriteLine($"Director approved ${amount}");
        else Console.WriteLine($"${amount} requires board approval");
    }
}

class ChainOfResponsibility
{
    static void Main(string[] args)
    {
        var tl = new TeamLead();
        tl.SetNext(new Manager()).SetNext(new Director());

        double[] amounts = { 500, 5000, 50000, 200000 };
        foreach (var a in amounts) tl.Handle(a);
    }
}
