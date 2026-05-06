// Program: GetTypeInfo
// Difficulty: Medium
// Description: Retrieves type information at runtime using reflection.
using System;
using System.Reflection;

class GetTypeInfo
{
    class Sample
    {
        public int PublicField = 0;
        private string _private = "secret";
        public string Name { get; set; }
        public void Method1() {}
        protected virtual void Method2() {}
    }

    static void Main(string[] args)
    {
        Type t = typeof(Sample);
        Console.WriteLine($"Type: {t.FullName}");
        Console.WriteLine($"Assembly: {t.Assembly.GetName().Name}");
        Console.WriteLine($"Base: {t.BaseType?.Name}");
        Console.WriteLine($"IsClass: {t.IsClass}");
        Console.WriteLine($"IsSealed: {t.IsSealed}");
        Console.WriteLine($"IsAbstract: {t.IsAbstract}");
        Console.WriteLine($"Namespace: {t.Namespace ?? "(none)"}");

        var fields  = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        var props   = t.GetProperties();
        var methods = t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        Console.WriteLine($"Fields: {string.Join(", ", System.Linq.Enumerable.Select(fields, f => f.Name))}");
        Console.WriteLine($"Properties: {string.Join(", ", System.Linq.Enumerable.Select(props, p => p.Name))}");
        Console.WriteLine($"Methods: {string.Join(", ", System.Linq.Enumerable.Select(methods, m => m.Name))}");
    }
}
