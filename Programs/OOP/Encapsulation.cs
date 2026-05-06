// Program: Encapsulation
// Difficulty: Medium
// Description: Demonstrates encapsulation with private fields and public properties.
using System;

class BankAccount
{
    private decimal balance;
    private string owner;

    public BankAccount(string owner, decimal initialBalance)
    {
        this.owner = owner;
        balance = initialBalance >= 0 ? initialBalance : throw new ArgumentException("Balance cannot be negative");
    }

    public string Owner => owner;
    public decimal Balance => balance;

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Deposit must be positive");
        balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > balance) return false;
        balance -= amount;
        return true;
    }

    public override string ToString() => $"Account[{owner}]: ${balance:F2}";
}

class Encapsulation
{
    static void Main(string[] args)
    {
        var account = new BankAccount("Alice", 1000m);
        account.Deposit(500m);
        Console.WriteLine(account);
        Console.WriteLine($"Withdraw $200: {account.Withdraw(200m)}");
        Console.WriteLine(account);
        Console.WriteLine($"Withdraw $2000: {account.Withdraw(2000m)}");
    }
}
