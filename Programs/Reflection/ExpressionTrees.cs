// Program: ExpressionTrees
// Difficulty: High
// Description: Builds and compiles expression trees for dynamic code generation.
using System;
using System.Linq.Expressions;

class ExpressionTrees
{
    static Func<double, double, double> BuildCalculator(string op)
    {
        var a = Expression.Parameter(typeof(double), "a");
        var b = Expression.Parameter(typeof(double), "b");
        Expression body = op switch
        {
            "+" => Expression.Add(a, b),
            "-" => Expression.Subtract(a, b),
            "*" => Expression.Multiply(a, b),
            "/" => Expression.Divide(a, b),
            "^" => Expression.Call(typeof(Math).GetMethod("Pow"), a, b),
            _ => throw new ArgumentException($"Unknown op: {op}")
        };
        return Expression.Lambda<Func<double, double, double>>(body, a, b).Compile();
    }

    static void Main(string[] args)
    {
        foreach (var op in new[] { "+", "-", "*", "/", "^" })
        {
            var func = BuildCalculator(op);
            Console.WriteLine($"5 {op} 3 = {func(5, 3)}");
        }

        // Build predicate expression tree
        var param = Expression.Parameter(typeof(int), "x");
        var pred = Expression.Lambda<Func<int, bool>>(
            Expression.AndAlso(
                Expression.GreaterThan(param, Expression.Constant(2)),
                Expression.LessThan(param, Expression.Constant(8))), param).Compile();

        int[] nums = { 1, 3, 5, 7, 9 };
        Console.Write("Between 2 and 8: ");
        foreach (var n in nums) if (pred(n)) Console.Write(n + " ");
        Console.WriteLine();
    }
}
