// Program: GetMethods
// Difficulty: Medium
// Description: Discovers and inspects methods at runtime using reflection.
using System;
using System.Linq;
using System.Reflection;

class GetMethods
{
    class Calculator
    {
        public int Add(int a, int b) => a + b;
        public double Divide(double a, double b) => b != 0 ? a / b : double.NaN;
        public string Format(double value, string format = "F2") => value.ToString(format);
        private static int Hidden() => 42;
    }

    static void Main(string[] args)
    {
        Type t = typeof(Calculator);
        var methods = t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);

        Console.WriteLine($"Methods in {t.Name}:");
        foreach (var m in methods)
        {
            string access = m.IsPublic ? "public" : m.IsPrivate ? "private" : "protected";
            string stat   = m.IsStatic ? " static" : "";
            var parms = m.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}");
            Console.WriteLine($"  {access}{stat} {m.ReturnType.Name} {m.Name}({string.Join(", ", parms)})");
        }
    }
}
