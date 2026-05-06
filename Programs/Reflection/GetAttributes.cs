// Program: GetAttributes
// Difficulty: Medium
// Description: Reads custom attributes from types and members using reflection.
using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
class VersionAttribute : Attribute
{
    public string Value { get; }
    public VersionAttribute(string version) => Value = version;
}

[AttributeUsage(AttributeTargets.Property)]
class RequiredAttribute : Attribute
{
    public string Message { get; set; } = "This field is required.";
}

[Version("2.1.0")]
class UserService
{
    [Required(Message = "Name is required")]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Version("1.5.0")]
    public void CreateUser() => Console.WriteLine("Creating user...");
}

class GetAttributes
{
    static void Main(string[] args)
    {
        Type t = typeof(UserService);
        var classAttr = t.GetCustomAttribute<VersionAttribute>();
        Console.WriteLine($"Class version: {classAttr?.Value}");

        foreach (var prop in t.GetProperties())
        {
            var req = prop.GetCustomAttribute<RequiredAttribute>();
            if (req != null) Console.WriteLine($"  {prop.Name}: {req.Message}");
        }

        foreach (var method in t.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance))
        {
            var v = method.GetCustomAttribute<VersionAttribute>();
            if (v != null) Console.WriteLine($"  {method.Name} v{v.Value}");
        }
    }
}
