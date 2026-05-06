// Program: AbstractClass
// Difficulty: Medium
// Description: Shows abstract classes as blueprints that cannot be instantiated.
using System;

abstract class Employee
{
    public string Name { get; set; }
    public Employee(string name) => Name = name;
    public abstract decimal CalculateSalary();
    public virtual void ShowInfo() =>
        Console.WriteLine($"{GetType().Name} - {Name}: ${CalculateSalary():F2}/month");
}

class FullTimeEmployee : Employee
{
    decimal monthlySalary;
    public FullTimeEmployee(string name, decimal salary) : base(name) => monthlySalary = salary;
    public override decimal CalculateSalary() => monthlySalary;
}

class ContractEmployee : Employee
{
    decimal hourlyRate;
    int hoursWorked;
    public ContractEmployee(string name, decimal rate, int hours) : base(name)
    { hourlyRate = rate; hoursWorked = hours; }
    public override decimal CalculateSalary() => hourlyRate * hoursWorked;
}

class AbstractClass
{
    static void Main(string[] args)
    {
        Employee[] employees = {
            new FullTimeEmployee("Alice", 5000m),
            new ContractEmployee("Bob", 50m, 80)
        };
        foreach (var e in employees) e.ShowInfo();
    }
}
