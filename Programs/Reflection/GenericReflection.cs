// Program: GenericReflection
// Difficulty: High
// Description: Uses reflection to work with generic types and methods.
using System;
using System.Collections.Generic;
using System.Reflection;

class GenericReflection
{
    static T ConvertValue<T>(object value) => (T)Convert.ChangeType(value, typeof(T));

    static object CallGenericMethod(string value, Type targetType)
    {
        var method = typeof(GenericReflection).GetMethod(nameof(ConvertValue),
            BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
        var generic = method.MakeGenericMethod(targetType);
        return generic.Invoke(null, new object[] { value });
    }

    static void Main(string[] args)
    {
        // Invoke generic methods via reflection
        var types = new[] { typeof(int), typeof(double), typeof(bool) };
        string[] values = { "42", "3.14", "true" };
        for (int i = 0; i < types.Length; i++)
        {
            object result = CallGenericMethod(values[i], types[i]);
            Console.WriteLine($"'{values[i]}' -> {result} ({result.GetType().Name})");
        }

        // Inspect generic type
        Type listType = typeof(List<string>);
        Console.WriteLine($"
Type: {listType.Name}");
        Console.WriteLine($"IsGeneric: {listType.IsGenericType}");
        Console.WriteLine($"Args: {string.Join(", ", listType.GetGenericArguments().Select(t => t.Name))}");
        Console.WriteLine($"Definition: {listType.GetGenericTypeDefinition().Name}");
    }
}
